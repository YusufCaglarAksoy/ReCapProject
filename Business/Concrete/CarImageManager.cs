using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            string path = ImagePaths.ImageFolderPath + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(carImage.ImagePath, path);
            carImage.ImagePath = path;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            File.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage.CarId), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            string deletePath = _carImageDal.Get(cI => cI.CarId == carImage.CarId).ImagePath;
            File.Delete(deletePath);

            string path = ImagePaths.ImageFolderPath + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(carImage.ImagePath, path);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetById(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdExists(Id));
            if (!result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = ImagePaths.ImageDefaultPath } });
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cI => cI.CarId == Id), Messages.CarImagesListed);
        }



        private IResult CheckIfCarImageLimitedExceded(int Id)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == Id).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarIdExists(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count();
            if (result == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImagePathTypeCorrect(string imagePath)
        {
            string acceptableExtensions = ".jpg";
            if (string.Compare(imagePath, acceptableExtensions) == 0)
            {
                return new ErrorResult(Messages.CarImagePathTypeIsFalse);
            }
            return new SuccessResult();
        }
    }
}

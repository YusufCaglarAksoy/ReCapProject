﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

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
        public IResult Add(IFormFile file, CarImage carImage)
        {
            //var result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage));

            //if(result != null)
            //{
            //    return result;
            //}
            
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(I => I.carImageId == carImage.carImageId).ImagePath;

            var result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitedExceded(carImage), CheckIfCarImagePathTypeCorrect(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.carImageId == carImage.carImageId).ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int Id)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdExists(Id));
            if (result!=null)
            {
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\logo.png");
                return new ErrorDataResult<List<CarImage>>(new List<CarImage> { new CarImage { CarId = Id, ImagePath = path, Date = DateTime.Now } },result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cI => cI.CarId == Id), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.carImageId == id));
        }

        private IResult CheckIfCarImageLimitedExceded(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

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
            string acceptableExtensions = ".jpg|png|jpeg";
            if (string.Compare(imagePath, acceptableExtensions) == 0)
            {
                return new ErrorResult(Messages.CarImagePathTypeIsFalse);
            }
            return new SuccessResult();
        }
    }
}

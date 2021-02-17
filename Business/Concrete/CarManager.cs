using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        EfCarDal _carDal;
        InputManager inputManager = new InputManager();
        public CarManager(EfCarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<Car> GetById()
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == inputManager.InputId()));
        }

        public IResult Add()
        {
            Car car = inputManager.InputCar();
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarDecriptionInvalid);
            }
            else if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarPriceInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new Result(true, Messages.CarAdded);
            }
        }

        public IResult Delete()
        {
            _carDal.Delete(inputManager.InputCar());
            return new Result(true, Messages.CarDeleted);
        }

        public IResult Update()
        {
            _carDal.Update(inputManager.InputCar());
            return new Result(true, Messages.CarUpdated);
        }
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        

        public IDataResult<List<Car>> GetCarsByBrandId()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == inputManager.InputId()),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == inputManager.InputId()), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }
    }
    }

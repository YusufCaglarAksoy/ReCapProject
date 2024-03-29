﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        private ICarService _carService;
        private ICustomerService _customerService;
        InputManager inputManager = new InputManager();
        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.RentalId == Id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarIdAvailable(rental.CarId),CheckFindeksPoint(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = null;
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {   

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalsListed);
        }

        public IResult CheckFindeksPoint(Rental rental)
        {
            var cars = _carService.GetById(rental.CarId).Data;
            var findeksPoint = _customerService.GetById(rental.CustomerId).Data.FindeksScore;
            foreach (var car in cars)
            {
                if (car.FindeksScore > findeksPoint)
                {
                    return new ErrorResult("Findeks Puanı Yetersiz");
                }    
            }
            return new SuccessResult();

        }

        private IResult CheckIfCarIdAvailable(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarIdNotAvailable);
            }
            return new SuccessResult();
        }
    }
}

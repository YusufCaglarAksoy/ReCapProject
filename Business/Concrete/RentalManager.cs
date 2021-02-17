using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        EfRentalDal _rentalDal;
        InputManager inputManager = new InputManager();
        public RentalManager(EfRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IDataResult<Rental> GetById()
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == inputManager.InputId()));
        }
        public IResult Add()
        {
            Rental rental = inputManager.InputRental();
            var car = _rentalDal.GetAll(c => c.Id == rental.Id);

            foreach (var c in car)
            {
                if (c.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalErrorAdded);
                }
            }
            _rentalDal.Add(rental);
            rental.ReturnDate = null;
            return new Result(true, Messages.RentalAdded);

            
        }

        public IResult Delete()
        {
            _rentalDal.Delete(inputManager.InputRental());
            return new Result(true, Messages.RentalDeleted);
        }

        public IResult Update()
        {
            _rentalDal.Update(inputManager.InputRental());
            return new Result(true, Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }
    }
}

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
    public class CustomerManager : ICustomerService
    {
        EfCustomerDal _customerDal;
        InputManager inputManager = new InputManager();
        public CustomerManager(EfCustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<Customer> GetById()
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == inputManager.InputId()));
        }
        public IResult Add()
        {
            _customerDal.Add(inputManager.InputCustomer());
            return new Result(true, Messages.CustomerAdded);
        }

        public IResult Delete()
        {
            _customerDal.Delete(inputManager.InputCustomer());
            return new Result(true, Messages.CustomerDeleted);
        }

        public IResult Update()
        {
            _customerDal.Update(inputManager.InputCustomer());
            return new Result(true, Messages.CustomerUpdated);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }
    }
}

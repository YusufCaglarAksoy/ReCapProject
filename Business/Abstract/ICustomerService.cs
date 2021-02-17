using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetById();
        IDataResult<List<Customer>> GetAll();
        IResult Add();
        IResult Update();
        IResult Delete();
    }
}

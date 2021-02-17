using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById();
        IDataResult<List<User>> GetAll();
        IResult Add();
        IResult Update();
        IResult Delete();
    }
}

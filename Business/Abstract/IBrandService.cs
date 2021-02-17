using Core.Utilities.Results;
using Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById();
        IDataResult<List<Brand>> GetAll();
        IResult Add();
        IResult Update();
        IResult Delete();
    }
}

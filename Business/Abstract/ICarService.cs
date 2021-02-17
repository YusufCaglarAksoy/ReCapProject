using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById();
        IDataResult<List<Car>> GetAll();
        IResult Add();
        IResult Update();
        IResult Delete();
        IDataResult<List<Car>> GetCarsByBrandId();
        IDataResult<List<Car>> GetCarsByColorId();
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
    }
}

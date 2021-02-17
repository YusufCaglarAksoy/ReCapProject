using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetById();
        IDataResult<List<Color>> GetAll();
        IResult Add();
        IResult Update();
        IResult Delete();
    }
}

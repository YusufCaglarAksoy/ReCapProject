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
        IDataResult<Color> GetById(int Id);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}

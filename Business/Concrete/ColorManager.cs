using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;
        InputManager inputManager = new InputManager();
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<Color> GetById(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == Id));
        }
        public IResult Add(Color color)
        { 
            _colorDal.Add(color);
            return new Result(true, Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, Messages.ColorDeleted);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }
        
    }
}

using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        EfColorDal _colorDal;
        InputManager inputManager = new InputManager();
        public ColorManager(EfColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<Color> GetById()
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == inputManager.InputId()));
        }
        public IResult Add()
        { 
            _colorDal.Add(inputManager.InputColor(false));
            return new Result(true, Messages.ColorAdded);
        }

        public IResult Delete()
        {
            _colorDal.Delete(inputManager.InputColor(true));
            return new Result(true, Messages.ColorDeleted);
        }

        public IResult Update()
        {
            _colorDal.Update(inputManager.InputColor(true));
            return new Result(true, Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }
        
    }
}

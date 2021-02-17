using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        EfBrandDal _brandDal;
        InputManager inputManager = new InputManager();
        public BrandManager(EfBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IDataResult<Brand> GetById()
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.Id == inputManager.InputId()),Messages.BrandsListed);
        }
        public IResult Add()
        {
            _brandDal.Add(inputManager.InputBrand(false));
            return new Result(true, Messages.BrandAdded);
        }

        public IResult Delete()
        {
            _brandDal.Delete(inputManager.InputBrand(true));
            return new Result(true, Messages.BrandDeleted);
        }

        public IResult Update()
        {
            _brandDal.Update(inputManager.InputBrand(true));
            return new Result(true, Messages.BrandUpdated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }
        
    }
}

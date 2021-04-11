using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Set<Car>().Where(filter)
                             join b in context.Brands on c.BrandId equals b.brandId
                             join co in context.Colors on c.ColorId equals co.colorId
                             join ci in context.CarImages on c.carId equals ci.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.carId,
                                 ColorId = co.colorId,
                                 BrandId = b.brandId,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 DailyPrice= c.DailyPrice,
                                 ColorName = co.ColorName,
                                 ImagePath = ci.ImagePath,
                                 FindeksScore=c.FindeksScore
                             };
                return result.ToList();
            }  
        }

    }
}

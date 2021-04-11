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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Set<Rental>().Where(filter)
                             join c in context.Cars on r.CarId equals c.carId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 carId = r.CarId,
                                 rentalId = r.RentalId,
                                 customerId=r.CustomerId,
                                 CarName = c.CarName,
                                 CustomerName = cu.CompanyName,
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate                          
                             };
                return result.ToList();
            }
        }

    }
}

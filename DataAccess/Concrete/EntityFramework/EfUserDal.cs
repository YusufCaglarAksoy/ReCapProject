using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = from oC in context.OperationClaims
                             join uOC in context.UserOperationClaims on oC.Id equals uOC.OperationClaimId where uOC.UserId == user.UserId
                             select new OperationClaim 
                             { 
                                 Id = oC.Id, 
                                 Name = oC.Name 
                             };
                return result.ToList();

            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entity.Dtos;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, YagDunyasiDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new YagDunyasiDbContext())
            {
                var result = from opClaims in context.OperationClaims
                             join userOpClaims in context.UserOperationClaims
                             on opClaims.Id equals userOpClaims.OperationClaimId
                             where user.Id == userOpClaims.UserId
                             select new OperationClaim { Id = opClaims.Id, Name = opClaims.Name };
                return result.ToList();
            }
        }

    }
}

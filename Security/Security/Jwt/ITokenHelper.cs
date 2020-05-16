using Core.Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Security.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

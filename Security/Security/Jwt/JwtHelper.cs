using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Security.Security.Encryption;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Security.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configuration;
        private TokenOptions _tokenOptions;
        private DateTime _tokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            string token = jwtHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _tokenExpiration
            };
        }

        JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _tokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, user.Name));
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()));
            operationClaims.Select(p => p.Name).ToList()
                .ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

            return claims;
        }
    }
}

using Entity.Concrete;
using Entity.Dtos;
using Security.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetUserById(int userId);
        User GetUserByTelephoneNumber(string telephoneNumber);
        User GetUserByEmail(string email);
        List<User> GetUsersByName(string name);
        List<User> GetUserByStatusId(int statusId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        bool UserExist(int userId);
        bool UserExistByMail(string email);
        List<OperationClaim> GetClaims(User user);

        (User user, string message, bool isSuccess) Login(LoginDto loginDto);
        (User user, string message, bool isSuccess) Register(RegisterDto registerDto);
        AccessToken CreateAccessToken(User user);
    }
}

using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Security.Security.Hashing;
using Security.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;
        public UserManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = GetClaims(user);
            return _tokenHelper.CreateToken(user, claims);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userDal.Get(p => p.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _userDal.Get(p => p.Id == userId);
        }

        public List<User> GetUserByStatusId(int statusId)
        {
            return _userDal.GetList(p => p.UserStatusId == statusId).ToList();
        }

        public User GetUserByTelephoneNumber(string telephoneNumber)
        {
            return _userDal.Get(p => p.TelephoneNumber == telephoneNumber);
        }

        public List<User> GetUsersByName(string name)
        {
            return _userDal.GetList(p => p.Name.Contains(name)).ToList();
        }

        public (User user, string message, bool isSuccess) Login(LoginDto loginDto)
        {
            if (!UserExistByMail(loginDto.Email))
            {
                return (null, Messages.Messages.UserNotFound, false);
            }

            var user = _userDal.Get(p => p.Email == loginDto.Email);
            if (!HashHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return (null, Messages.Messages.LoginPasswordNotMatch, false);
            }

            return (user, Messages.Messages.UserLoginSucceed, true);
        }

        public (User user, string message, bool isSuccess) Register(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);

            if (UserExistByMail(registerDto.Email))
            {
                return (null, Messages.Messages.UserAlreadyExist, false);
            }

            User user = new User
            {
                Name = registerDto.FirstName,
                Surname = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Address = registerDto.Address,
                Email = registerDto.Email,
                TelephoneNumber = registerDto.TelephoneNumber,
                UserStatusId = 2
            };

            _userDal.Add(user);
            return (user, Messages.Messages.UserRegisterSucceed, true);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public bool UserExist(int userId)
        {
            if (_userDal.Get(p => p.Id == userId) == null)
            {
                return false;
            }
            return true;
        }

        public bool UserExistByMail(string email)
        {
            if (_userDal.Get(p => p.Email == email) == null)
            {
                return false;
            }
            return true;
        }
    }
}

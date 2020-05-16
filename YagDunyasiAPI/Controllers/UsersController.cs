using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Messages;
using Entity.Concrete;
using Entity.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YagDunyasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult UserRegister(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest("Gönderilen bilgiler boş.");
            }
            var (user, message, isSucceed) = _userService.Register(registerDto);
            if (!isSucceed)
            {
                return BadRequest(message);
            }
            var accessToken = _userService.CreateAccessToken(user);

            return Ok(accessToken);
        }

        [HttpGet("login")]
        public IActionResult UserLogin(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Gönderilen bilgiler boş.");
            }
            var (user, message, isSucceed) = _userService.Login(loginDto);
            if (!isSucceed)
            {
                return BadRequest(message);
            }
            var accessToken = _userService.CreateAccessToken(user);

            return Ok(accessToken);
        }

        [HttpPost("updateUser")]
        public IActionResult UpdateUser(User user)
        {
            var userEntity = _userService.GetUserById(user.Id);
            user.PasswordHash = userEntity.PasswordHash;
            user.PasswordSalt = userEntity.PasswordSalt;
            _userService.Update(user);

            return Ok(Messages.UserUpdated);
        }

        [HttpPost("changeUserStatus")]
        public IActionResult ChangeUserStatus(int userId, int statusId)
        {
            var userToChangeStatus = _userService.GetUserById(userId);
            userToChangeStatus.UserStatusId = statusId;
            _userService.Update(userToChangeStatus);
            return Ok(Messages.UserStatusChanged + " Yeni durumu: " + statusId);
        }
    }
}
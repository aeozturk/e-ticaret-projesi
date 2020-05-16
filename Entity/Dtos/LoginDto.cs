using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

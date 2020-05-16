using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class RegisterDto : IDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
    }
}

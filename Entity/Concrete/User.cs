using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int UserStatusId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Order> Orders { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}

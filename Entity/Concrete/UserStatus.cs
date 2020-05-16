using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class UserStatus : IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

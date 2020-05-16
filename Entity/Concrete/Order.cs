using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }
        public User User { get; set; }
    }
}

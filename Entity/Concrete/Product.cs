using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public string Viskozite { get; set; }
        public double Liter { get; set; }
        public int TradeMarkId { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductAddDate { get; set; }
        public string Barkod { get; set; }
        public bool isProductActive { get; set; }

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
        public virtual TradeMark TradeMark { get; set; }

    }
}

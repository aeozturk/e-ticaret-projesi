using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class TradeMark : IEntity
    {
        public int Id { get; set; }
        public string TradeMarkName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

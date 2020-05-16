using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class ProductAddDto : IDto
    {
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public string Viskozite { get; set; }
        public double Liter { get; set; }
        public int TradeMarkId { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public DateTime ProductAddDate { get; set; }
        public string Barkod { get; set; }
    }
}

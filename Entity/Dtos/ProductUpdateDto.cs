using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public string Viskozite { get; set; }
        public double Liter { get; set; }
        public int TradeMarkId { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public string Barkod { get; set; }
    }
}

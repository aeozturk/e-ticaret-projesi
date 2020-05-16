using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ListFilters
{
    public class ProductListFilters
    {
        public string SearchingProductName { get; set; }
        public string Viskozite { get; set; }
        public double? Liter { get; set; }
        public int? MaxStockCount { get; set; }
        public int? TradeMarkId { get; set; }
        public bool? isProductActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ListFilters
{
    public class OrderListFilters
    {
        public int? OrderStatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MinTotalPrice { get; set; }
        public decimal? MaxTotalPrice { get; set; }
    }
}

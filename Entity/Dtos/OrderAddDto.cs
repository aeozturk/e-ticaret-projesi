using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class OrderAddDto : IDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public decimal OrderTotalPrice { get; set; }

        public int OrderStatusId { get; set; }
        public List<OrderedProductsDto> OrderedProductsList { get; set; }
    }
}

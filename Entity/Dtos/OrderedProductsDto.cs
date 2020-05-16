using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class OrderedProductsDto : IDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}

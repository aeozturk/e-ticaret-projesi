using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public int? OrderStatusId { get; set; }
    }
}

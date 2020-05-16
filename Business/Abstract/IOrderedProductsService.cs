using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderedProductsService
    {
        List<OrderedProduct> GetByProductName(string productName);
        List<OrderedProduct> GetByOrderId(int orderId);

        void Add(OrderedProduct orderedProduct);
        void Update(OrderedProduct orderedProduct);
        void Delete(OrderedProduct orderedProduct);
    }
}

using Entity.Concrete;
using Entity.ListFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Order GetById(int orderId);
        List<Order> GetOrderList(OrderListFilters orderListFilters);
        List<Order> GetByUserId(int userId);
        List<Order> GetByDateRange(DateTime startDate, DateTime endDate);
        Order Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        void AddOrderedProduct(OrderedProduct orderedProduct);

        bool isOrderExist(int productId);
    }
}

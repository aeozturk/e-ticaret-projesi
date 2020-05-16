using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ListFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IOrderedProductDal _orderedProductDal;
        private IMailService _emailService;
        private IUserDal _userDal;




        public OrderManager(IOrderDal orderDal, IOrderedProductDal orderedProductDal, IMailService emailService, IUserDal userDal)
        {
            _orderDal = orderDal;
            _orderedProductDal = orderedProductDal;
            _emailService = emailService;
            _userDal = userDal;
        }

        public Order Add(Order order)
        {
            _orderDal.Add(order);
            var admins = _userDal.GetList(u => u.UserStatusId == 1).ToList();
            var user = _userDal.Get(u => u.Id == order.UserId);
            foreach (var admin in admins)
            {
                _emailService.SendOrderMail(admin.Email, "Yeni Sipariş!", order);
            }
            _emailService.SendOrderMail(user.Email, "Siparişiniz Alındı!", order);
            return order;
        }

        public void AddOrderedProduct(OrderedProduct orderedProduct)
        {
            _orderedProductDal.Add(orderedProduct);
        }

        public void Delete(Order order)
        {
            _orderDal.Delete(order);
        }

        public List<Order> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _orderDal.GetList(p => p.OrderDate < endDate && p.OrderDate > startDate).ToList();
        }

        public Order GetById(int orderId)
        {
            return _orderDal.Get(p => p.Id == orderId);
        }

        public List<Order> GetByUserId(int userId)
        {
            return _orderDal.GetList(p => p.User.Id == userId).ToList();
        }

        public List<Order> GetOrderList(OrderListFilters orderListFilters)
        {
            var orders = _orderDal.GetList().ToList();

            if (orderListFilters.EndDate != null && orderListFilters.StartDate != null)
            {
                orders = orders.Where(o => o.OrderDate < orderListFilters.EndDate && o.OrderDate > orderListFilters.StartDate).ToList();
            }
            if (orderListFilters.OrderStatusId != null)
            {
                orders = orders.Where(o => o.OrderStatusId == orderListFilters.OrderStatusId).ToList();
            }
            if (orderListFilters.MaxTotalPrice != null && orderListFilters.MinTotalPrice != null)
            {
                orders = orders.Where(o => o.OrderTotalPrice < orderListFilters.MaxTotalPrice && o.OrderTotalPrice > orderListFilters.MinTotalPrice).ToList();
            }

            return orders;
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }

        public bool isOrderExist(int productId)
        {
            if (_orderDal.Get(o => o.Id == productId) == null)
            {
                return false;
            }
            return true;
        }
    }
}

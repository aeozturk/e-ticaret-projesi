using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderedProductsManager : IOrderedProductsService
    {
        private IOrderedProductDal _orderedProductDal;

        public OrderedProductsManager(IOrderedProductDal orderedProductDal)
        {
            _orderedProductDal = orderedProductDal;
        }

        public void Add(OrderedProduct orderedProduct)
        {
            _orderedProductDal.Add(orderedProduct);
        }

        public void Delete(OrderedProduct orderedProduct)
        {
            _orderedProductDal.Delete(orderedProduct);
        }

        public List<OrderedProduct> GetByOrderId(int orderId)
        {
            return _orderedProductDal.GetList(p => p.Order.Id == orderId).ToList();
        }

        public List<OrderedProduct> GetByProductName(string productName)
        {
            return _orderedProductDal.GetList(p => p.Product.ProductName == productName).ToList();
        }

        public void Update(OrderedProduct orderedProduct)
        {
            _orderedProductDal.Update(orderedProduct);
        }
    }
}

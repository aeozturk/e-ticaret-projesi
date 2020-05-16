using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ListFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            var entity = GetProductById(product.Id);
            entity.isProductActive = false;
            Update(entity);
        }

        public List<Product> GetProductList(ProductListFilters productListFilters)
        {
            var products = _productDal.GetList().ToList();

            if (productListFilters.SearchingProductName != null)
            {
                products = products.Where(o => o.ProductName.ToLower().Contains(productListFilters.SearchingProductName.ToLower())).ToList();
            }
            if (productListFilters.Viskozite != null)
            {
                products = products.Where(o => o.Viskozite == productListFilters.Viskozite).ToList();
            }
            if (productListFilters.Liter != null)
            {
                products = products.Where(o => o.Liter == productListFilters.Liter).ToList();
            }
            if (productListFilters.MaxStockCount != null)
            {
                products = products.Where(o => o.StockCount > productListFilters.MaxStockCount).ToList();
            }
            if (productListFilters.TradeMarkId != null)
            {
                products = products.Where(o => o.TradeMarkId == productListFilters.TradeMarkId).ToList();
            }
            if (productListFilters.isProductActive != null)
            {
                products = products.Where(o => o.isProductActive == productListFilters.isProductActive).ToList();
            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            return _productDal.Get(p => p.Id == productId);
        }

        public Product GetProductByName(string productName)
        {
            return _productDal.Get(p => p.ProductName.ToLower() == productName.ToLower());
        }

        public List<Product> GetProductListByName(string productName)
        {
            return _productDal.GetList(p => p.ProductName.Contains(productName)).ToList();
        }

        public List<Product> GetProductListByTradeMarkId(int tradeMarkId)
        {
            return _productDal.GetList(p => p.TradeMarkId == tradeMarkId).ToList();
        }

        public List<Product> GetProductListByViskozite(string viskozite)
        {
            return _productDal.GetList(p => p.Viskozite == viskozite).ToList();
        }

        public bool isBarkodDuplicate(Product product)
        {
            if (_productDal.GetList(p => p.Barkod == product.Barkod && p.Id != product.Id).ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool isProductExistsByBarkod(string barkod)
        {
            if (_productDal.Get(p => p.Barkod == barkod) == null)
            {
                return false;
            }
            return true;
        }

        public bool isProductExistsById(int productId)
        {
            if (_productDal.Get(p => p.Id == productId) == null)
            {
                return false;
            }
            return true;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}

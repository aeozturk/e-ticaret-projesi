using Entity.Concrete;
using Entity.ListFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        Product GetProductByName(string productName);
        List<Product> GetProductListByName(string productName);
        List<Product> GetProductListByViskozite(string viskozite);
        List<Product> GetProductListByTradeMarkId(int tradeMarkId);
        List<Product> GetProductList(ProductListFilters productListFilters);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        bool isProductExistsByBarkod(string barkod);
        bool isProductExistsById(int productId);
        bool isBarkodDuplicate(Product product);

    }
}

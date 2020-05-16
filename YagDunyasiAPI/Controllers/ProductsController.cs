using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstract;
using Business.Messages;
using Entity.Concrete;
using Entity.Dtos;
using Entity.ListFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YagDunyasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct(ProductAddDto productAddDto)
        {
            var addingProduct = _mapper.Map<ProductAddDto, Product>(productAddDto);
            addingProduct.ProductAddDate = DateTime.Now;
            if (_productService.isProductExistsByBarkod(addingProduct.Barkod))
            {
                return BadRequest(Messages.ProductExists);
            }
            _productService.Add(addingProduct);
            return Ok(Messages.ProductAdded);
        }

        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            if (!_productService.isProductExistsById(product.Id))
            {
                return BadRequest(Messages.ProductNotFound);
            }
            if (_productService.isBarkodDuplicate(product))
            {
                return BadRequest(Messages.ProductBarkodAlreadyExist);
            }
            var entity = _productService.GetProductById(product.Id);
            product.ProductAddDate = entity.ProductAddDate;

            _productService.Update(product);
            return Ok(Messages.ProductUpdated);
        }

        [HttpPost("deleteProduct")]
        public IActionResult DeleteProduct(Product product)
        {
            if (!_productService.isProductExistsById(product.Id))
            {
                return BadRequest(Messages.ProductNotFound);
            }

            _productService.Delete(product);
            return Ok(Messages.ProductDeleted);
        }

        [HttpGet("getProducts")]
        public IActionResult GetProducts(ProductListFilters productListFilters)
        {
            return Ok(_productService.GetProductList(productListFilters));
        }

        [HttpGet("getProductListByTradeMarkId")]
        public IActionResult GetProductByTradeMarkId(int tradeMarkId)
        {
            var productList = _productService.GetProductListByTradeMarkId(tradeMarkId);
            if (productList.Count == 0)
            {
                return BadRequest(Messages.TradeMarkHaveNotProduct);
            }

            return Ok(productList);
        }

        [HttpGet("getProductListByViskozite")]
        public IActionResult GetProductByViskozite(string viskozite)
        {
            var productList = _productService.GetProductListByViskozite(viskozite);
            if (productList.Count == 0)
            {
                return BadRequest(Messages.ViskoziteNotFound);
            }

            return Ok(productList);
        }

        [HttpGet("getProductListByName")]
        public IActionResult GetProductListByName(string productName)
        {
            var productList = _productService.GetProductListByName(productName);
            if (productList.Count == 0)
            {
                return BadRequest(Messages.ProductNotFound);
            }

            return Ok(productList);
        }
    }
}
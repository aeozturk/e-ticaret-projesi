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
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("addOrder")]
        public IActionResult AddOrder(OrderAddDto orderAddDto)
        {
            var addingOrder = _mapper.Map<OrderAddDto, Order>(orderAddDto);
            addingOrder.OrderDate = DateTime.Now;

            var addedOrder = _orderService.Add(addingOrder);

            foreach (var orderedProduct in orderAddDto.OrderedProductsList)
            {
                OrderedProduct op = new OrderedProduct();
                op.OrderId = addedOrder.Id;
                op.ProductId = orderedProduct.ProductId;
                op.Count = orderedProduct.Count;

                _orderService.AddOrderedProduct(op);
            }
            return Ok(Messages.OrderAdded);
        }

        [HttpPost("updateOrder")]
        public IActionResult UpdateOrder(OrderUpdateDto orderUpdateDto)
        {
            var updatingOrder = _orderService.GetById(orderUpdateDto.Id);
            if (updatingOrder == null)
            {
                return BadRequest(Messages.OrderNotFound);
            }
            if (orderUpdateDto.OrderStatusId!=null)
            {
                updatingOrder.OrderStatusId = (int)orderUpdateDto.OrderStatusId;
            }
            _orderService.Update(updatingOrder);
            return Ok(Messages.OrderUpdated);
        }

        [HttpGet("getOrders")]
        public IActionResult GetOrders(OrderListFilters orderListFilters)
        {

            return Ok(_orderService.GetOrderList(orderListFilters));
        }
    }
}
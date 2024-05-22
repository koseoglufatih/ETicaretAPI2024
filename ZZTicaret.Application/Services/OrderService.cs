using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.DTO.Order;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Domain;

namespace ZZTicaret.Application.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(CreateOrder createorder)
        {
            var order = await _orderRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                UserId = createorder.UserId,
                OrderDate = DateTime.Now,
                 

            });

            await _orderRepository.SaveAsync();
           
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var user = await _orderRepository.GetByIdAsync(orderId);
            if (user != null)
            {
                _orderRepository.Delete(user);
                await _orderRepository.SaveAsync();
            }
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return new List<OrderViewModel>();
        }

        public async Task<OrderViewModel> GetOrderById(Guid orderId)
        {
            var order = _orderRepository.GetByIdAsync(orderId);
            return new OrderViewModel();
        }

        public async Task UpdateOrder(Guid orderId, OrderViewModel model)
        {
            var order = _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception(" Order Not Updated.");   
            }

            await _orderRepository.SaveAsync();
        }
    }
}
    

      
 

      

       



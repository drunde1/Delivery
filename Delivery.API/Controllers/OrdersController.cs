using Delivery.API.Contracts;
using Delivery.Application.Services;
using Delivery.Core.Models;
using Delivery.DataAccess.Reposetories;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            try
            {
                var orders = await _ordersService.GetOrders();

                var response = orders
                    .Select(o => new OrdersResponse(o.Id, o.Weight, o.District, o.DeliveryTime));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{district},{firstDeliveryTime:datetime}")]
        public async Task<ActionResult<List<Order>>> GetFilteredOrders(string district, DateTime firstDeliveryTime)
        {
            try
            {
                var orders = await _ordersService.GetFiltered(district, firstDeliveryTime);

                var response = orders
                    .Select(o => new OrdersResponse(o.Id, o.Weight, o.District, o.DeliveryTime));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}

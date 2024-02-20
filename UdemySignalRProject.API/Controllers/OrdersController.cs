using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetTotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {

            return Ok(_orderService.TTotalOrderCount());
        }
        [HttpGet("GetActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {

            return Ok(_orderService.TActiveOrderCount());
        }
        [HttpGet("GetLastOrderPrice")]
        public IActionResult GetLastOrderPrice()
        {

            return Ok(_orderService.TLastOrderPrice());
        }
        [HttpGet("GetDateNowTotalPrice")]
        public IActionResult GetDateNowTotalPrice()
        {
            return Ok(_orderService.TDateNowTotalPrice());
        }
    }
}

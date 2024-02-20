using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCasesService;

        public MoneyCasesController(IMoneyCaseService moneyCasesService)
        {
            _moneyCasesService = moneyCasesService;
        }

        [HttpGet("GetMoneyCaseTotalAmount")]
        public IActionResult GetMoneyCaseTotalAmount()
        {
            return Ok( _moneyCasesService.TGetMoneyCaseTotalAmaount());
        }
    }
}

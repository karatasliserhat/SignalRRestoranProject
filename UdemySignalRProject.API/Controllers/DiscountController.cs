using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var values = await _discountService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var data = _mapper.Map<Discount>(createDiscountDto);
            await _discountService.TAddAsync(data);

            return Ok("İndirim  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountAsync(int id)
        {
            var value = await _discountService.TGetByIdAsync(id);

            await _discountService.TDeleteAsync(value);
            return Ok("İndirim  silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var data = _mapper.Map<Discount>(updateDiscountDto);
            await _discountService.TUpdateAsync(data);
            return Ok("İndirim  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountAsync(int id)
        {

            return Ok(await _discountService.TGetByIdAsync(id));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DiscountChangeStatusTrue(int id)
        {
            await _discountService.ChangeStautusTrue(id);
            return Ok("İndirim Aktif Edildi");
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DiscountChangeStatusFalse(int id)
        {

            await _discountService.ChangeStautusFalse(id);
            return Ok("İndirim Pasif Edildi");
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> DiscountListStatusTrue()
        {

            var dataMap = _mapper.Map<List<ResultDiscountDto>>(await _discountService.StatusTrueList());
            return Ok(dataMap);
        }


    }
}

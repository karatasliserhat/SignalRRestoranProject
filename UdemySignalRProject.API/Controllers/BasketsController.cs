using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public BasketsController(IBasketService basketService, IMapper mapper, IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> BasketList()
        {
            var values = await _basketService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBasketAsync(CreateBasketDto createBasketDto)
        {
            var dataProduct = await _productService.TGetByIdAsync(createBasketDto.ProductId);
            createBasketDto.ProductId = dataProduct.ProductId;
            createBasketDto.Price= dataProduct.Price;
            createBasketDto.Count = 1;
            createBasketDto.TotalPrice = createBasketDto.Count * createBasketDto.Price;
            createBasketDto.MenuTableId = 8;
            var data = _mapper.Map<Basket>(createBasketDto);
            await _basketService.TAddAsync(data);

            return Ok("Sepete  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasketAsync(int id)
        {
            var value = await _basketService.TGetByIdAsync(id);

            await _basketService.TDeleteAsync(value);
            return Ok("Sepetteki ürün silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasketAsync(UpdateBasketDto updateBasketDto)
        {
            var data = _mapper.Map<Basket>(updateBasketDto);
            await _basketService.TUpdateAsync(data);
            return Ok("Sepetteki Ürün Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasketAsync(int id)
        {

            return Ok(await _basketService.TGetByIdAsync(id));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBasketByMasaTable(int id)
        {
            var values = await _basketService.TGetBasketByMenuTableNumberAsync(id);
            return Ok(_mapper.Map<List<ResultBasketByMasaTableNameWithProductNameDto>>(values));

        }
    }
}

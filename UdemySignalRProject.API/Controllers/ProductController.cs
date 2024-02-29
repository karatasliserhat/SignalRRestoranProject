using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            return Ok(await _productService.TGetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(CreateProductDto createProductDto)
        {
            var data = _mapper.Map<Product>(createProductDto);
            await _productService.TAddAsync(data);
            return Ok("Ürün Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productService.TGetByIdAsync(id));
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TProductCount());
        }


        [HttpGet("GetProductPriceAvg")]
        public IActionResult GetProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("GetProductMinPrice")]
        public IActionResult GetProductMinPrice()
        {
            return Ok(_productService.TProductMinPrice());
        }

        [HttpGet("GetProductMaxPrice")]
        public IActionResult GetProductMaxPrice()
        {
            return Ok(_productService.TProductMaxPrice());
        }

        [HttpGet("GetProductAvgByCategoryNameHamburger")]
        public IActionResult GetProductAvgByCategoryNameHamburger()
        {
            return Ok(_productService.TProductAvgByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("GetProductWithCategories")]
        public async Task<IActionResult> GetProductWithCategories()
        {
            var datas = await _productService.GetProductsWithCategories();
            var datasMap = _mapper.Map<List<ResultProductWithGetCategory>>(datas);
            return Ok(datasMap);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var data = await _productService.TGetByIdAsync(id);
            await _productService.TDeleteAsync(data);

            return Ok("Ürün silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var data = _mapper.Map<Product>(updateProductDto);
            await _productService.TUpdateAsync(data);

            return Ok("Ürün Güncellendi");
        }
    }
}

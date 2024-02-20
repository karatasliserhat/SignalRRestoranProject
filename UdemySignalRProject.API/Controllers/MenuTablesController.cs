using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MenuTableList()
        {
            var datas = await _menuTableService.TGetAllAsync();
            var mapData = _mapper.Map<List<ResultMenuTableDto>>(datas);
            return Ok(mapData);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetMenuTableId(int id)
        {
            var data = await _menuTableService.TGetByIdAsync(id);
            return Ok(_mapper.Map<ResultMenuTableDto>(data));
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            await _menuTableService.TAddAsync(_mapper.Map<MenuTable>(createMenuTableDto));
            return Ok("Masa Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            await _menuTableService.TUpdateAsync(_mapper.Map<MenuTable>(updateMenuTableDto));
            return Ok("Masa Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
           var data= await _menuTableService.TGetByIdAsync(id);
            await _menuTableService.TDeleteAsync(data);
            return Ok("Masa Silindi");
        }
        [HttpGet("GetMenuTableCount")]
        public IActionResult GetMenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
    }
}

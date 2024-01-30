﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemySignalRProject.BusinessLayer.Abstract;
using UdemySignalRProject.DTO.Dtos;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.TGetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryDto createCategorygDto)
        {
            var data = _mapper.Map<Category>(createCategorygDto);
            await _categoryService.TAddAsync(data);

            return Ok("Kategori  Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var value = await _categoryService.TGetByIdAsync(id);

            await _categoryService.TDeleteAsync(value);
            return Ok("Kategori  silinmiştir");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var data = _mapper.Map<Category>(updateCategoryDto);
            await _categoryService.TUpdateAsync(data);
            return Ok("Kategori  Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {

            return Ok(await _categoryService.TGetByIdAsync(id));
        }
    }
}
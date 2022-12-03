using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
        {
            var res = new Response<List<ProductCategoryDto>>()
            {
                Data = await _service.GetAllAsync()
            };
            return Ok(res);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id)
        {
            var res = new Response<ProductCategoryDto>();

            if (!await _service.ProductCategoryExist(id))
            {
                res.Errors.Add("No encontrado");
                return NotFound(res);
            }
            res.Data = await _service.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
        {
            var res = new Response<ProductCategoryDto>();

            if (await _service.ExistByName(categoryDto.Name))
            {
                res.Errors.Add($"Producto con nombre {categoryDto.Name} ya existe");
            }
            res.Data = await _service.SaveAsync(categoryDto);

            return CreatedAtAction("Get", new { id = res.Data.Id }, res);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response<bool>>> Delete(int id)
        {
            var res = new Response<bool>()
            {
                Data = await _service.DeleteAsync(id)
            };
            return Ok(res);
        }
        [HttpPut]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Put([FromBody] ProductCategoryDto dto)
        {
            var response = new Response<ProductCategoryDto>();

            if (!await _service.ProductCategoryExist(dto.Id))
            {
                response.Errors.Add("Product Category Not Found");
                return NotFound(response);
            }

            if (await _service.ExistByName(dto.Name, dto.Id))
            {
                response.Errors.Add($"Product Category name {dto.Name} already exists");
                return BadRequest(response);
            }
            response.Data = await _service.UpdateAsync(dto);
            return Ok(response);
        }
    }

}
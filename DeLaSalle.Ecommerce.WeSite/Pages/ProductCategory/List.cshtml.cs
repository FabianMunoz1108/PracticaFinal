using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.ProductCategory
{
    public class ListModel : PageModel
    {
        private readonly IProductCategoryService _service;
        public List<ProductCategoryDto> Productos { get; set; }

        public ListModel(IProductCategoryService service)
        {
            _service = service;
            Productos = new List<ProductCategoryDto>();
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await _service.GetAllAsync();
            Productos = response.Data;
            return Page();
        }
    }
}
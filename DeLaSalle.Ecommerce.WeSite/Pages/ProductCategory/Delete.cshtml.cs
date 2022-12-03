using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.ProductCategory
{
    public class DeleteModel : PageModel
    {
        private readonly IProductCategoryService _service;

        [BindProperty]
        public ProductCategoryDto Producto { get; set; }

        public DeleteModel(IProductCategoryService service)
        {
            _service = service;
            Producto = new ProductCategoryDto();
        }
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                var response = await _service.GetById(id.Value);
                Producto = response.Data;
            }
            if(Producto == null)
            {
                return RedirectToAction("./error404");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Producto.Id > 0)
            {
               var res =  await _service.DeleteAsync(Producto.Id);
            }
            return RedirectToPage("./List");

        }
    }
}

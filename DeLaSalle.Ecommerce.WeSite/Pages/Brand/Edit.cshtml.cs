using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Brand
{
    public class EditModel : PageModel
    {
        private readonly IBrandService _service;

        [BindProperty]
        public BrandDto Marca { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public EditModel(IBrandService service, IConfiguration conf)
        {
            _service = service;
            Marca = new BrandDto();
            _service.UrlAPI = conf.GetValue<string>("UrlApi");
            _service.Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJmbXVub3oiLCJpc3MiOiJXZWJBcGlKd3QuY29tIiwiYXVkIjoibG9jYWxob3N0In0.KEjbLrLdqbHNRCC7fUwYgebxGndQH9bAc67LmopUUXA";
        }

        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                var res = await _service.GetByIdAsync(id.Value);
                Marca = res.Data;
            }
            return Page();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Response<BrandDto> res;

            if (Marca.Id > 0)
            {
                res = await _service.UpdateAsync(Marca);
            }
            else
            {
                res = await _service.SaveAsync(Marca);
            }
            Errors = res.Errors;

            if (Errors.Count > 0)
            {
                return Page();
            }
            return RedirectToPage("./List");
        }
    }
}
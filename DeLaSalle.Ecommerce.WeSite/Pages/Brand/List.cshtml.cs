using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Brand
{
    public class ListModel : PageModel
    {
        private readonly IBrandService _service;
        public List<BrandDto> Marcas { get; set; }

        public ListModel(IBrandService service, IConfiguration conf)
        {
            _service = service;
            Marcas = new List<BrandDto>();

            _service.UrlAPI = conf.GetValue<string>("UrlApi");
            _service.Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJmbXVub3oiLCJpc3MiOiJXZWJBcGlKd3QuY29tIiwiYXVkIjoibG9jYWxob3N0In0.KEjbLrLdqbHNRCC7fUwYgebxGndQH9bAc67LmopUUXA";
        }

        public async Task<IActionResult> OnGet()
        {
            var res = await _service.GetAllAsync();
            if (res != null)
            {
                Marcas = res.Data;
            }
            return Page();
        }
    }
}
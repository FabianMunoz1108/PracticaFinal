using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Brand
{
    public class DeleteModel : PageModel
    {
        private readonly IBrandService _service;

        [BindProperty]
        public BrandDto Marca { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        #region Constructores
        public DeleteModel(IBrandService service, IConfiguration conf)
        {
            _service = service;

            Marca = new BrandDto();
            _service.UrlAPI = conf.GetValue<string>("UrlApi");
            _service.Token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiJmbXVub3oiLCJpc3MiOiJXZWJBcGlKd3QuY29tIiwiYXVkIjoibG9jYWxob3N0In0.KEjbLrLdqbHNRCC7fUwYgebxGndQH9bAc67LmopUUXA";
        }
        #endregion

        #region Métodos
        public async Task<ActionResult> OnGetAsync(int id)
        {
            var res = await _service.GetByIdAsync(id);
            Errors = res.Errors;
            Marca = res.Data;
            return Page();
        }
        public async Task<ActionResult> OnPostAsync()
        {
            var res = await _service.DeleteAsync(Marca.Id);
            return RedirectToPage("./List");
        }
        #endregion
    }
}
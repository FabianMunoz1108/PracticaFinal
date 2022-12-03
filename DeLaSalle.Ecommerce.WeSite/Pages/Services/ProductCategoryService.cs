using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services
{
    public class ProductCategoryService : IProductCategoryService
    {

        private string _baseUrl = "https://localhost:7276/";
        private string _endpoint = "api/ProductCategories";

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var url = $"{_baseUrl}{_endpoint}/{id}";
            var client = new HttpClient();
            var res = await client.DeleteAsync(url);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(json);
        }

        public async Task<Response<List<ProductCategoryDto>>> GetAllAsync()
        {
            var url = $"{_baseUrl}{_endpoint}";
            var client = new HttpClient();
            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);
        }

        public async Task<Response<ProductCategoryDto>> GetById(int id)
        {
            var url = $"{_baseUrl}{_endpoint}/{id}";
            var client = new HttpClient();
            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        }

        public async Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto dto)
        {
            var url = $"{_baseUrl}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PostAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        }

        public async Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto dto)
        {
            var url = $"{_baseUrl}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PutAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        }
    }
}
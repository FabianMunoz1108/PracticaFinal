using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Newtonsoft.Json;
using System;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services
{
    public class BrandService : IBrandService
    {
        #region Propiedades
        public string UrlAPI { get; set; }
        public string Token { get; set; }
        #endregion

        #region Métodos
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var url = $"{UrlAPI}/{id}";
            var client = new HttpClient();
            var res = await client.DeleteAsync(url);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(json);
        }

        public async Task<Response<List<BrandDto>>> GetAllAsync()
        {
            var client = new HttpClient();
            var res = await client.GetAsync(UrlAPI);
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<List<BrandDto>>>(json);
        }

        public async Task<Response<BrandDto>> GetByIdAsync(int id)
        {
            var url = $"{UrlAPI}/{id}";
            var client = new HttpClient();
            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }

        public async Task<Response<BrandDto>> SaveAsync(BrandDto dto)
        {
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PostAsync(UrlAPI, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }

        public async Task<Response<BrandDto>> UpdateAsync(BrandDto dto)
        {
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PutAsync(UrlAPI, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }
        #endregion
    }
}
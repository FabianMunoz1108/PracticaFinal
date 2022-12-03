using DeLaSalle.Ecommerce.Api.Repositories;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services
{
    public class ProductCategoryService : IProductCategoryService
    {

        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<ProductCategoryDto>> GetAllAsync()
        {
            var cats = await _repository.GetAllAsync();
            return cats.Select(c => new ProductCategoryDto(c)).ToList();
        }

        public async Task<ProductCategoryDto> GetByIdAsync(int id)
        {
            var cat = await _repository.GetById(id);
            if (cat == null)
                throw new Exception("Product no encontrado");

            return new ProductCategoryDto(cat);

        }

        public async Task<bool> ProductCategoryExist(int id)
        {
            var category = await _repository.GetById(id);
            return category != null;
        }

        public async Task<ProductCategoryDto> SaveAsync(ProductCategoryDto categoryDto)
        {
            var cat = new ProductCategory
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreatedBy = "",
                CreatedDate = DateTime.Now,
                UpdatedBy = "",
                UpdatedDate = DateTime.Now
            };
            cat = await _repository.SaveAsync(cat);
            categoryDto.Id = cat.Id;
            return categoryDto;
        }

        public async Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto categoryDto)
        {
            var cat = await _repository.GetById(categoryDto.Id);
            if (cat == null)
                throw new Exception("Product no encontrado");
            categoryDto.Name = cat.Name;
            categoryDto.Description = cat.Description;
            //categoryDto.UpdatedBy = "";
            //categoryDto.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(cat);
            return categoryDto;
        }
        public async Task<bool> ExistByName(string name, int id = 0)
        {
            var category = await _repository.GetByName(name, id);

            return category != null;
        }
    }
}
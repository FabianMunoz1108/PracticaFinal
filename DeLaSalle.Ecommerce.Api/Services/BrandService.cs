using DeLaSalle.Ecommerce.Api.Repositories;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Api.Services.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> BrandExistAsync(int id)
        {
            var marca = await _repository.GetByIdAsync(id);
            return (marca != null);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> ExistByNameAsync(string name, int id = 0)
        {
            var marca = await _repository.GetByNameAsync(name, id);
            return marca != null;
        }

        public async Task<List<BrandDto>?> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(b => new BrandDto(b)).ToList();
        }

        public async Task<BrandDto?> GetByIdAsync(int id)
        {
            var brand = await _repository.GetByIdAsync(id);

            if (brand != null)
            {
                return new BrandDto(brand);
            }
            return null;
        }

        public async Task<BrandDto> SaveAsync(BrandDto dto)
        {
            Brand marca = new()
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedDate = DateTime.Now,
                CreatedBy = "",
            };
            marca = await _repository.SaveAsync(marca);
            return new BrandDto(marca);
        }

        public async Task<BrandDto> UpdateAsync(BrandDto dto)
        {
            Brand marca = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                UpdatedDate = DateTime.Now,
                UpdatedBy = "",
            };
            marca = await _repository.UpdateAsync(marca);
            return new BrandDto(marca);
        }
    }
}
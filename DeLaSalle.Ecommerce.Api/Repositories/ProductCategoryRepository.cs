using Dapper;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private IDbContext _context;
        public ProductCategoryRepository(IDbContext context)
        {
            _context = context;
        }
        public async Task<ProductCategory> SaveAsync(ProductCategory category)
        {
            category.Id = await _context.Connection.InsertAsync(category);
            return category;

        }
        public async Task<List<ProductCategory>> GetAllAsync()
        {
            const string sql = "SELECT * FROM ProductCategory WHERE IsDeleted = 0;";
            var categories = await _context.Connection.QueryAsync<ProductCategory>(sql);
            return categories.ToList();

        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetById(id);
            if (category != null)
            {
                category.IsDeleted = true;
                return await _context.Connection.UpdateAsync(category);
            }
            return false;
        }
        public async Task<ProductCategory> GetById(int id)
        {
            return await _context.Connection.GetAsync<ProductCategory>(id);
        }
        public async Task<ProductCategory> UpdateAsync(ProductCategory category)
        {
            await _context.Connection.UpdateAsync(category);
            return category;
        }
        public async Task<ProductCategory> GetByName(string name, int id = 0)
        {
            var sql = $"SELECT *  FROM ProductCategory WHERE Name = '{name}' AND Id <> {id} ";
            var categories =
                await _context.Connection.QueryAsync<ProductCategory>(sql);
            return categories.ToList().FirstOrDefault();
        }
    }
}
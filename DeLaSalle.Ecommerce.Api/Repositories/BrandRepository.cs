using Dapper;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Api.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        #region Globales
        private IDbContext _context;
        #endregion

        #region Constructores
        public BrandRepository(IDbContext context)
        {
            _context = context;
        }
        #endregion

        #region métodos
        /// <summary>
        /// Borrado lógico de marca
        /// </summary>
        /// <param name="id">Id de marca a borrar</param>
        /// <returns>Valor booleano que indica si se eliminó el registro</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await GetByIdAsync(id);
            if (marca != null && !marca.IsDeleted)
            {
                marca.IsDeleted = true;
                marca.UpdatedDate = DateTime.Now;
                return await _context.Connection.UpdateAsync(marca);
            }
            return false;
        }
        /// <summary>
        /// Obtiene el listado de todas las marcas que no están eliminadas
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public async Task<List<Brand>> GetAllAsync()
        {
            const string sql = "SELECT * FROM brand WHERE IsDeleted = 0;";
            var datos = await _context.Connection.QueryAsync<Brand>(sql);
            return datos.ToList();
        }
        /// <summary>
        /// Obtiene el detalle de la marca
        /// </summary>
        /// <param name="id">Id de marca</param>
        /// <returns>Info de marca</returns>
        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Connection.GetAsync<Brand>(id);
        }
        /// <summary>
        /// Almacena un nuevo registro
        /// </summary>
        /// <param name="brand">Marca a crear</param>
        /// <returns>Marca creada</returns>
        public async Task<Brand> SaveAsync(Brand brand)
        {
            brand.Id = await _context.Connection.InsertAsync(brand);
            return brand;
        }
        /// <summary>
        /// Actualiza el registro de marca
        /// </summary>
        /// <param name="brand">Marca a actualizar</param>
        /// <returns>Marca actualizada</returns>
        public async Task<Brand> UpdateAsync(Brand brand)
        {
            var existe = await GetByIdAsync(brand.Id);

            /*Actualización de registro, solo si no está eliminado*/
            if (existe != null && !existe.IsDeleted)
            {
                /*Preservar cambios existentes*/
                existe.Name = brand.Name;
                existe.Description = brand.Description;
                existe.UpdatedDate = brand.UpdatedDate;
                existe.UpdatedBy = brand.UpdatedBy;

                await _context.Connection.UpdateAsync(existe);
            }
            else
            {
                /*Se establece el Id en cero para indicar que no existe el registro*/
                brand.Id = 0;
            }
            return brand;
        }
        public async Task<Brand?> GetByNameAsync(string name, int id)
        {
            var sql = $"SELECT * FROM `brand` WHERE IsDeleted = 0 AND Name = '{name}' AND Id <> {id}";
            var marcas = await _context.Connection.QueryAsync<Brand>(sql);
            return marcas.ToList().FirstOrDefault();
        }
        #endregion
    }
}
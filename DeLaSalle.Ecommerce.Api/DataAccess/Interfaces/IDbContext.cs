using System.Data.Common;

namespace DeLaSalle.Ecommerce.Api.DataAccess.Interfaces
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }
    }
}
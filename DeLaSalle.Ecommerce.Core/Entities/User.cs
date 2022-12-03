using Dapper.Contrib.Extensions;

namespace DeLaSalle.Ecommerce.Core.Entities
{
    public class User
    {
        [ExplicitKey]
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
        public bool IsDeleted { get; set; }
    }
}
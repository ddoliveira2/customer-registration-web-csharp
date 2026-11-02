using customer_registration_web_csharp.Models;
using System.Data.Entity;

namespace customer_registration_web_csharp.Dal.Dao
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() : base("Server=localhost;Database=CustomerDb;User Id=sa;Password=123456;TrustServerCertificate=True;")
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}

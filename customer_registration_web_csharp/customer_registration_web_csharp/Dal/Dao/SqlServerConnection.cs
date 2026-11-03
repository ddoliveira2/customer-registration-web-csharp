using customer_registration_web_csharp.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace customer_registration_web_csharp.Dal.Dao
{
    public class SqlServerConnection
    {
        private readonly IDbConnection _connection;
        private string _strConnection = "Server=localhost;Database=CustomerDb;User Id=sa;Password=123456;TrustServerCertificate=True;";


        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_strConnection);
        }

        public List<T> GetTable<T>(string sql)
        {
            using (IDbConnection conn = CreateConnection())
            {
                using (var db = CreateConnection())
                {
                    return db.Query<T>(sql).ToList();
                }
            }
        }

        public void ExecuteSql<T>(string sql, T obj)
        {
            using (IDbConnection conn = CreateConnection())
            {
                conn.Execute(sql, obj);
            }
        }
    }
}

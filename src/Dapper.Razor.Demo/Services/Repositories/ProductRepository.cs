using Dapper.Razor.Demo.Configuration;
using Dapper.Razor.Demo.Models;
using Dapper.Razore.Demo.Services.Repositories.Base;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Dapper.Razor.Demo.Services.Repositories
{
    /// <summary>
    /// Products repository
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly SqlServerOptions _sqlServerOptions;

        public ProductRepository(IOptions<SqlServerOptions> sqlServerOptions)
            : base(sqlServerOptions.Value.SqlServerConnection, sqlServerOptions.Value.ProductsTableName)
        {
            _sqlServerOptions = sqlServerOptions.Value;
        }

        /// <summary>
        /// Create Products data table if not exists
        /// </summary>
        /// <returns></returns>
        public async Task CreateTableIfNotExistsAsync()
        {
            using var connection = new SqliteConnection(_sqlServerOptions.SqlServerConnection);
            await connection.ExecuteAsync($"CREATE TABLE IF NOT EXISTS { _sqlServerOptions.ProductsTableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name TEXT NOT NULL, Model TEXT NOT NULL, Price INTEGER NOT NULL, Obsolete BOOLEAN DEFAULT(FALSE), ModifiedDate DATETIME DEFAULT CURRENT_TIMESTAMP)").ConfigureAwait(false);
        }
    }
}

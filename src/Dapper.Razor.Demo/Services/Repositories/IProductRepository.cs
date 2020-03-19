using Dapper.Razor.Demo.Models;
using Dapper.Razore.Demo.Services.Repositories.Base;
using System.Threading.Tasks;

namespace Dapper.Razor.Demo.Services.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task CreateTableIfNotExistsAsync();
    }
}

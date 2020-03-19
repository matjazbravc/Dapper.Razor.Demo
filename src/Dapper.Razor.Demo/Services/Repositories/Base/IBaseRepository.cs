using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper.Razore.Demo.Services.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<int> DeleteAsync(int id);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(int id);

        Task<int> InsertAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);
    }
}

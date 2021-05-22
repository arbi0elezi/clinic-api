using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApi.Data_Models.Repos
{
    public interface IRepo <TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<bool> Delete(TEntity entity);
    }
}

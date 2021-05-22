using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApi.Data_Models.Repo_UoW
{
    public interface IRepoUnitOfWork
    {
        TRepo GetRepo<TRepo>() where TRepo : class;
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        ClinicModelContainer GetDbContext();
    }
}

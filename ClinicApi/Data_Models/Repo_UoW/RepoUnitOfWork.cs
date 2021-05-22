using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using StructureMap;

namespace ClinicApi.Data_Models.Repo_UoW
{
    public class RepoUnitOfWork : IRepoUnitOfWork
    {
        private readonly IContainer _container;
        private readonly ClinicModelContainer _context;

        public RepoUnitOfWork(IContainer container, ClinicModelContainer context)
        {
            _container = container;
            _context = context;
        }

        public TRepo GetRepo<TRepo>() where TRepo : class
        {
            return _container.GetInstance<TRepo>();
        }

        public bool SaveChanges() => _context.SaveChanges() > 0;

        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync()) > 0;
        public ClinicModelContainer GetDbContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
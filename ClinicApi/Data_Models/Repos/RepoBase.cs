using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClinicApi.Data_Models.Repos
{
    public class RepoBase<TEntity> : IRepo<TEntity> where TEntity : IEntity
    {
        private readonly DbContext _context;

        public RepoBase(DbContext context)
        {
            _context = context;
        }
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var result = await _context.Set<TEntity>()
                .Where(f => f.Id.Equals(id))
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new NoNullAllowedException();

            _context.Entry(entity).State = EntityState.Added;

            var flag = await _context.SaveChangesAsync();

            if (flag == 0) throw new EntitySqlException();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
                throw new NoNullAllowedException();

            _context.Entry(entity).State = EntityState.Modified;

            var flag = await _context.SaveChangesAsync();

            if (flag == 0) throw new EntitySqlException();

            return entity;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            if (entity == null)
                throw new NoNullAllowedException();

            _context.Entry(entity).State = EntityState.Deleted;

            var flag = await _context.SaveChangesAsync();

            return flag != 0;
        }
    }
}
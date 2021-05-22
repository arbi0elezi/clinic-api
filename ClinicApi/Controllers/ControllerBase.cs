using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ClinicApi.Data_Models;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos;
using ClinicApi.Data_Models.Repos.PsychologistRepo;

namespace ClinicApi.Controllers
{
    public abstract class ControllerBase<TEntity> : ApiController
        where TEntity : IEntity
    {
        private readonly IRepo<TEntity> _repo;
       

        public ControllerBase(IRepo<TEntity> repo)
        {
            _repo = repo;
        }
        // GET: api/Psychologist
        public async Task<IHttpActionResult>  Get()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Psychologist/5
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var result = await _repo.GetAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST: api/Psychologist
        public async Task<IHttpActionResult> Post([FromBody] TEntity value)
        {
            try
            {
                var result = await _repo.AddAsync(value);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Psychologist/5
        public async Task<IHttpActionResult> Put(Guid id, [FromBody] TEntity value)
        {
            try
            {
                var entity = await _repo.GetAsync(id);
                if (entity == null) return NotFound();

                var result = await _repo.Update(value);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Psychologist/5
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var entity = await _repo.GetAsync(id);
            if (entity == null) return BadRequest();
            var result = await _repo.Delete(entity);
            return result ? (IHttpActionResult) Ok() : BadRequest();
        }
    }

    
}

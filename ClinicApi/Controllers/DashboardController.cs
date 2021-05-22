using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos.SessionRepo;

namespace ClinicApi.Controllers
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        private readonly ISessionRepo _sessionRepo;

        public DashboardController(IRepoUnitOfWork uow)
        {
            _sessionRepo = uow.GetRepo<ISessionRepo>();
        }

        [HttpGet]
        [Route("psychologist")]
        public async Task<IHttpActionResult> GetSessionByPsychologistId(Guid id)
        {
            var result = await _sessionRepo.GetSessionsByPsychologistId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("client")]
        public async Task<IHttpActionResult> GetSessionByClientId(Guid id)
        {
            var result = await _sessionRepo.GetSessionsByClientId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("daily-sessions")]
        public async Task<IHttpActionResult> GetDailySessionNumberByInterval(DateTime from, DateTime to)
        {
            var result = await _sessionRepo.GetNumberOfSessionsPerDayByInterval(from, to);
            return Ok(result);
        }

        [HttpGet]
        [Route("top-psychologists")]
        public async Task<IHttpActionResult> GetTopPsychologistsByInterval(DateTime from, DateTime to)
        {
            var result = await _sessionRepo.GetTopFivePsychologistsBySessionByInterval(from, to);
            return Ok(result);
        }

        [HttpGet]
        [Route("average-sessions")]
        public async Task<IHttpActionResult> GetAverageSessionsByInterval(DateTime from, DateTime to)
        {
            var result = await _sessionRepo.AverageNumberOfSessionsUsersHandByInterval(from, to);
            return Ok(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicApi.Data_Models;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos;
using ClinicApi.Data_Models.Repos.SessionRepo;

namespace ClinicApi.Controllers
{
    public class SessionController : ControllerBase<Session>
    {
        public SessionController(IRepoUnitOfWork uow) : base(uow.GetRepo<ISessionRepo>())
        {
        }
    }
}

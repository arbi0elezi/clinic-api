using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicApi.Data_Models;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos;
using ClinicApi.Data_Models.Repos.ClientRepo;

namespace ClinicApi.Controllers
{
    public class ClientController : ControllerBase<Client>
    {
        public ClientController(IRepoUnitOfWork uow) : base(uow.GetRepo<IClientRepo>())
        {
        }
    }
}

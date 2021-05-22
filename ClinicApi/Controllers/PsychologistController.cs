using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicApi.Data_Models;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos.PsychologistRepo;

namespace ClinicApi.Controllers
{
    public class PsychologistController : ControllerBase<Psychologist>
    {
        public PsychologistController(IRepoUnitOfWork uow) : base(uow.GetRepo<IPsychologistRepo>())
        {
        }
    }
}

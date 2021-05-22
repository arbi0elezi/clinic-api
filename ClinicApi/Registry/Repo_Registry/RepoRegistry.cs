using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicApi.Data_Models;
using ClinicApi.Data_Models.Repo_UoW;
using ClinicApi.Data_Models.Repos.ClientRepo;
using ClinicApi.Data_Models.Repos.PsychologistRepo;
using ClinicApi.Data_Models.Repos.SessionRepo;

namespace ClinicApi.Registry.Repo_Registry
{
    public class RepoRegistry : StructureMap.Registry
    {
        public RepoRegistry()
        {
            For<ClinicModelContainer>().Use(() => new ClinicModelContainer());
            For<IRepoUnitOfWork>().Use<RepoUnitOfWork>();

            For<IPsychologistRepo>().Use<PsychologistRepo>();
            For<IClientRepo>().Use<ClientRepo>();
            For<ISessionRepo>().Use<SessionRepo>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClinicApi.Data_Models.Repos.ClientRepo
{
    public class ClientRepo : RepoBase<Client>, IClientRepo
    {
        
        public ClientRepo(ClinicModelContainer context) : base(context)
        {
        }
    }
}
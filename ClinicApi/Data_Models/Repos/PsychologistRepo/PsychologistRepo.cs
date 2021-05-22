using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClinicApi.Data_Models.Repos.PsychologistRepo
{
    public class PsychologistRepo : RepoBase<Psychologist>, IPsychologistRepo
    {
        public PsychologistRepo(ClinicModelContainer context) : base(context)
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicApi.Data_Models.Local_Models;

namespace ClinicApi.Data_Models.Repos.SessionRepo
{
    public interface ISessionRepo : IRepo<Session>
    {
        Task<IList<Session>> GetSessionsByPsychologistId(Guid pid);

        Task<IList<Session>> GetSessionsByClientId(Guid cid);

        Task<IList<DailySessions>> GetNumberOfSessionsPerDayByInterval(DateTime from, DateTime to);

        Task<IList<PsychologistAndSessionCount>> GetTopFivePsychologistsBySessionByInterval(
            DateTime from,
            DateTime to);

        Task<AverageOfSessions> AverageNumberOfSessionsUsersHandByInterval(DateTime from,
            DateTime to);
    }
}

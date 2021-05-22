using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ClinicApi.Data_Models.Local_Models;

namespace ClinicApi.Data_Models.Repos.SessionRepo
{
    public class SessionRepo : RepoBase<Session>,  ISessionRepo
    {
        private readonly ClinicModelContainer _context;

        public SessionRepo(ClinicModelContainer context) : base(context)
        {
            _context = context;
        }


        public async Task<IList<Session>> GetSessionsByPsychologistId(Guid pid)
        {
            return await _context
                .Set<Session>()
                .Where(f => f.PsychologistId.Equals(pid))
                .ToListAsync();
        }

        public async Task<IList<Session>> GetSessionsByClientId(Guid cid)
        {
            return await _context
                .Set<Session>()
                .Where(f => f.PsychologistId.Equals(cid))
                .ToListAsync();
        }

        public async Task<IList<DailySessions>> GetNumberOfSessionsPerDayByInterval(DateTime from, DateTime to)
        {
            var result = await _context
                .Set<Session>()
                .Where(f => f.BookedDate >= from && f.BookedDate <= to)
                .ToListAsync();
            
            return result.GroupBy(f => f.BookedDate.Date)
                .Select(f => new DailySessions
                {
                    Count = f.Count(),
                    Date = f.Key
                })
                .OrderByDescending(f => f.Date)
                .ToList();
        }

        public async Task<IList<PsychologistAndSessionCount>> GetTopFivePsychologistsBySessionByInterval(
            DateTime from,
            DateTime to)
        {
            return await _context
                .Set<Session>()
                .Where(f => f.BookedDate >= from && f.BookedDate <= to)
                .GroupBy(f => f.PsychologistId)
                .Select(f => new PsychologistAndSessionCount
                {
                    Psychologist = f.FirstOrDefault().Psychologist,
                    Count = f.Count()
                })
                .OrderByDescending(f => f.Count)
                .Take(5)
                .ToListAsync();
        }

        public async Task<AverageOfSessions> AverageNumberOfSessionsUsersHandByInterval(DateTime from,
            DateTime to)
        {
            var result = await _context
                .Set<Session>()
                .Where(f => f.BookedDate >= from && f.BookedDate <= to)
                .GroupBy(f => f.ClientId)
                .Select(f => f.Count())
                .AverageAsync();

            return new AverageOfSessions
            {
                Average = result
            };
        }
    }
}
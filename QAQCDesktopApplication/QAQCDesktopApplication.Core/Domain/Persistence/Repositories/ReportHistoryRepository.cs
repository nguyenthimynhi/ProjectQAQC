using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;
using QAQCDesktopApplication.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Persistence.Repositories
{
    public class ReportHistoryRepository : IReportHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void InsertAsync(ReportHistory entry)
        {
            _context.reportHistory.Add(entry);
        }

        public IList<ReportHistory> Load(DateTime timestart, DateTime timestop)
        {
            var _timestart = timestart.AddHours(0).AddMinutes(0).AddSeconds(0);
            var _timestop = timestop.AddHours(0).AddMinutes(0).AddSeconds(0);
            var data = _context.reportHistory
                .Where(f => f.Date >= _timestart && f.Date <= _timestop)
                .ToList();
            return data;
        }
    }
}

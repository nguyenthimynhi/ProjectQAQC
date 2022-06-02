using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Persistence.Repositories
{
    public interface IReportHistoryRepository
    {
        void InsertAsync(ReportHistory entry);
        IList<ReportHistory> Load(DateTime timestart, DateTime timestop);
    }
}

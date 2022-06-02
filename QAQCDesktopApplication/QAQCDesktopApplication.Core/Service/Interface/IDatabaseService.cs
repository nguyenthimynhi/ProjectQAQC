using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Service.Interface
{
    public interface IDatabaseService
    {
        Task<ServiceResponse> InsertEditHistory(EditHistory standard);
        Task<IList<EditHistory>> LoadEditHistory(DateTime timestart, DateTime timestop);

        Task<ServiceResponse> InsertReportHistory(ReportHistory standard);
        Task<IList<ReportHistory>> LoadReportHistory(DateTime timestart, DateTime timestop);
    }
}

using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Service.Interface
{
    public interface IExcelExportService
    {
        Task<ServiceResponse> ExportTest(string path, ObservableCollection<qcreport> report);
    }
}

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
    public interface IImportExcelService
    {
        Task<ServiceResponse> Import(ObservableCollection<Machine> machine);
        Task<ServiceResponse> Export(ObservableCollection<Machine> report);
    }
}

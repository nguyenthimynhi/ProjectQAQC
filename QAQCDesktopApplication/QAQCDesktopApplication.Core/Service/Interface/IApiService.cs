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
    public interface IApiService
    {
        Task<ServiceResourceResponse<QueryResult<qcreport>>> GetReport(DateTime? startTime, DateTime? stopTime, string standardid);
        Task<ServiceResourceResponse<List<StandardDetail>>> GetStandard();
        Task<ServiceResponse> PostStandard(Standard standard);
        Task<ServiceResponse> DeleteStandard(string standard);
        Task<ServiceResponse> PutFiles(filePDF file);
        Task<ServiceResponse> PutImage(ImageError image);
        Task<ServiceResourceResponse<QueryResult<Product>>> GetProduct();
        Task<ServiceResourceResponse<filePDF>> GetFiles(string id);
        Task<ServiceResponse> PatchStandard(string id, StandardDetail standard);
    }
}

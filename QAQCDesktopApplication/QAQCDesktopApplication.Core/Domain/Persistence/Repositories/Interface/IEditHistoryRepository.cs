using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Persistence.Repositories
{
    public interface IEditHistoryRepository
    {
        void InsertAsync(EditHistory entry);
        IList<EditHistory> Load(DateTime timestart, DateTime timestop);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();
        //void DetachChange();
    }
}

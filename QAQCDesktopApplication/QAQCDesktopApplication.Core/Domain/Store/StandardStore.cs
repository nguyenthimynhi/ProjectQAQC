using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Store
{
    public class StandardStore
    {
        public Action<string, string, string, DateTime, ObservableCollection<AppearanceError>, ObservableCollection<Dimension>> StandardAdded;
        public void AddStandard(string idstandard, string fileName, string product, DateTime uploadDate, ObservableCollection<AppearanceError> appearances, ObservableCollection<Dimension> dimensions)
        {
            StandardAdded.Invoke(idstandard, fileName, product, uploadDate, appearances, dimensions);
        }
    }
}

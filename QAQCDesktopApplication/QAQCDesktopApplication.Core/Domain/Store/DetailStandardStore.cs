using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Store
{
    public class DetailStandardStore
    {
        public Action<string, string, Product, DateTime, ObservableCollection<AppearanceError>, ObservableCollection<Dimension>> StandardEdited;
        public void EditStandard(string idstandard, string fileName, Product product, DateTime uploadDate, ObservableCollection<AppearanceError> appearances, ObservableCollection<Dimension> dimensions)
        {
            StandardEdited.Invoke(idstandard, fileName, product, uploadDate, appearances, dimensions);
        }
    }
}

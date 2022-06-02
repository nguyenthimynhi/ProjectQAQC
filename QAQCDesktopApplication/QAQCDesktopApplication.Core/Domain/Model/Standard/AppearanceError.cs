using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class AppearanceError
    {
        public string name { get; set; }
        public AppearanceError(string Name)
        {
            name = Name;
        }
    }
}

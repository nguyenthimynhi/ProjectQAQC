using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class AppearanceResult
    {
        public string name { get; set; }
        public AppearanceResult(string Name)
        {
            name = Name;
        }
    }
}

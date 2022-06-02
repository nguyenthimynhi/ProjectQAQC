using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class Dimension
    {
        public string name { get; set; }
        public double upperBound { get; set; }
        public double lowerBound { get; set; }
        public Dimension(string Name, double upper, double lower)
        {
            name = Name;
            upperBound = upper;
            lowerBound = lower;
        }
    }
}

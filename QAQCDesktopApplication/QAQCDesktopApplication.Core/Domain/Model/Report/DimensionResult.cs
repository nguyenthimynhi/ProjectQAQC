using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class DimensionResult
    {
        public string name { get; set; }
        public int sampleNumber { get; set; }
        public double result { get; set; }
        public bool passed { get; set; }
    }
}

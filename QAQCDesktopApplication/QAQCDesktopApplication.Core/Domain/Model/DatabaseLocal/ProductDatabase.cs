using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.DatabaseLocal
{
    public class ProductDatabase
    {
        public int ID { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
        //public EditHistory editHistory { get; set; }
        //public ReportHistory reportHistory { get; set; }
    }
}

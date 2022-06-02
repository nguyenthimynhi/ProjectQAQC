using QAQCDesktopApplication.Core.Domain.DatabaseLocal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class EditHistory
    {     
        public string? User { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public string productId { get; set; }
        public string name { get; set; }
    }
}

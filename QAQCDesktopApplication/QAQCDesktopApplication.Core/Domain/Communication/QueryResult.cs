using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Communication
{
    public class QueryResult<T>
    {
        public List<T> items { get; set; } = new List<T>();
        public int totalItems { get; set; } = 0;
    }
}

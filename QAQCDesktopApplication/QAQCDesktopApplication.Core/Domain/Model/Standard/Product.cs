using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }

        public Product(string Id, string Name)
        {
            id = Id;
            name = Name;
        }       
    }
}

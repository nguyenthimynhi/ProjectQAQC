using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class Tester
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public Tester(string Id, string Lastname, string Firstname)
        {
            id = Id;
            lastName = Lastname;
            firstName = Firstname;
        }
    }
}

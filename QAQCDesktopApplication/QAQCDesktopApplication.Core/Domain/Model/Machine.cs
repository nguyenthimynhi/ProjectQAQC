using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class Machine
    {
        public string ID { get; set; }
        public string moldId { get; set; }
        public Product product { get; set; }
        public bool Thongsocaidat { get; set; }
        public bool Quytrinhhoatdong { get; set; }
        public bool Nhancong { get; set; }
        public bool Nhietdo { get; set; }
        public DateTime date { get; set; }
        public Machine(string Id,string moldid, Product Product, DateTime UploadDate, bool status1, bool status2, bool status3, bool status4)
        {     
            moldId = moldid;
            ID = Id;
            product = Product;
            date = UploadDate;
            Thongsocaidat = status1;
            Quytrinhhoatdong = status2;
            Nhancong = status3;
            Nhietdo = status4;
        }
    }
}

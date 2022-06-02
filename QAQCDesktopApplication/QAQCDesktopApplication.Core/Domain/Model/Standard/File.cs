using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class filePDF
    {
        public string standardId { get; set; }
        public byte[] fileData { get; set; }
        public filePDF (string Standard, byte[] filepath)
        {
            standardId = Standard;
            fileData = filepath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class ImageError
    {
        public string standardId { get; set; }
        public int appearanceErrorIndex { get; set; }
        public byte[] fileData { get; set; }
        public ImageError(string Standard, int index, byte[] filepath)
        {
            standardId = Standard;
            appearanceErrorIndex = index;
            fileData = filepath;
        }
    }
}

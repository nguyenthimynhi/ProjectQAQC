using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class Appearance : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private int _count = 0;

        // Tên hiển thị mỗi thành phần Chart
        public string Title
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        // Data cho Chart
        public int Value
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyPropertyChanged(nameof(Value));
            }
        }

        // Phần dưới là implement của INotifyPropertyChanged - tự động cập nhật data.
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

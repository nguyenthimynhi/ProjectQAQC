using MaterialDesignThemes.Wpf;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel.MessageBox
{

    public delegate void Notify();  // delegate
    public class NotifyBoxViewModel : BaseViewModel
    {      
        private string _contentText;
        //private PackIconKind _icon = PackIconKind.User;
        public static NotifyBoxViewModel Instance => new NotifyBoxViewModel();
        public string ContentText { get => _contentText; set { _contentText = value; OnPropertyChanged(); } }
        public ICommand CancelCommand { get; set; }
        public event Notify Cancel;

        public NotifyBoxViewModel()
        {
            CancelCommand = new RelayCommand(() => Cancel.Invoke());
        }
    }
}

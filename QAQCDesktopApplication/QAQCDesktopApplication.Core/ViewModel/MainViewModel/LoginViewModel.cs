using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        public string UserName
        { get { return _username; } set { _username = value; OnPropertyChanged(nameof(UserName)); OnPropertyChanged(nameof(IsLogined)); } }
        private string _password;
        public string Password { get { return _password; } set { _password = value;  OnPropertyChanged(nameof(Password)); OnPropertyChanged(nameof(IsLogined)); } }

        public bool IsLogined; /*=> !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);*/
        public ICommand LoggingCommand { get; set; }
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public LoginViewModel(NavigationStore navigationStore, INavigationService LoginNavigation)
        {
            IsLogined = false;
            Password = "nguyennhi";
            UserName = "";
            LoggingCommand = new NavigateCommand(LoginNavigation);
            //PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            //LoggingCommand = new RelayCommand(async () => await View());
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        //private Task View()
        //{
        //    IsLogined = true;
        //}

        //public MessageViewModel ErrorMessageViewModel { get; }

        //public string ErrorMessage
        //{
        //    set => ErrorMessageViewModel.Message = value;
        //}      

        //public override void Dispose()
        //{
        //    ErrorMessageViewModel.Dispose();

        //    base.Dispose();
        //}
    }
}

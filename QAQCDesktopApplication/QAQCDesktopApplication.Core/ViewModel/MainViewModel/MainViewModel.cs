using MaterialDesignThemes.Wpf;
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
    public class MainViewModel : BaseViewModel 
    {
        private string _user;
        public string User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public int SelectButton { get; set; }
        private bool _isBtnLogin;
        private bool _isBtnSV;
        private bool _isBtnHT;
        private bool _isBtnQA;
        private bool _isBtnQC;
        private string _login;
        public string Login { get => _login; set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public bool IsBtnLogin { get => _isBtnLogin; set { _isBtnLogin = value; OnPropertyChanged(nameof(IsBtnLogin)); } }
        public bool IsBtnQA { get => _isBtnQA; set { _isBtnQA = value; OnPropertyChanged(nameof(IsBtnQA)); } }
        public bool IsBtnSV { get => _isBtnSV; set { _isBtnSV = value; OnPropertyChanged(nameof(IsBtnSV)); } }
        public bool IsBtnHT { get => _isBtnHT; set { _isBtnHT = value; OnPropertyChanged(nameof(IsBtnHT)); } }
        public bool IsBtnQC { get => _isBtnQC; set { _isBtnQC = value; OnPropertyChanged(nameof(IsBtnQC)); } }
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand LoginCommand { get; set; }
        public ICommand QAViewCommand { get; set; }
        public ICommand QCViewCommand { get; set; }
        public ICommand SuperviseCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand SettingCommand { get; set; }

        public MainViewModel(NavigationStore navigationStore, INavigationService LoginNavigation, INavigationService QANavigation, INavigationService QCNavigation, INavigationService SVNavigation, INavigationService HTNavigation)
        {
            _navigationStore = navigationStore;
            LoginCommand = new NavigateCommand(LoginNavigation);
            QAViewCommand = new NavigateCommand(QANavigation);
            QCViewCommand = new NavigateCommand(QCNavigation);
            SuperviseCommand = new NavigateCommand(SVNavigation);
            HistoryCommand = new NavigateCommand(HTNavigation);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.CurrentButtonChanged += _navigationStore_CurrentButtonChanged;
            IsBtnLogin = true;
            IsBtnQA = false;
            IsBtnSV = false;
            IsBtnHT = false;
            IsBtnQC = false;
            User = "UserName";
            Login = "ĐĂNG NHẬP";
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        private void _navigationStore_CurrentButtonChanged()
        {
            SelectButton = _navigationStore.SelectButton;
            SwitchAnimationButton(SelectButton);
        }
        public void SwitchAnimationButton(int selectButton)
        {
            switch (selectButton)
            {
                case 1:
                    IsBtnLogin = true;
                    Login = "ĐĂNG NHẬP";
                    IsBtnQA = false;
                    IsBtnQC = false;
                    IsBtnHT = false;
                    User = "UserName";
                    break;
                case 2:
                    Login = "ĐĂNG XUẤT";
                    IsBtnLogin = false;
                    IsBtnQA = true;
                    IsBtnQC = false;
                    IsBtnHT = false;
                    IsBtnSV = false;
                    User = "Nguyen My Nhi";
                    break;
                case 3:
                    IsBtnLogin = false;
                    IsBtnQA = false;
                    IsBtnQC = true;
                    IsBtnHT = false;
                    IsBtnSV = false;
                    Login = "ĐĂNG XUẤT";
                    User = "Nguyen My Nhi";
                    break;
                case 4:
                    IsBtnLogin = false;
                    IsBtnQA = false;
                    IsBtnQC = false;
                    IsBtnHT = false;
                    IsBtnSV = true;
                    Login = "ĐĂNG XUẤT";
                    User = "Nguyen My Nhi";
                    break;
                case 5:
                    IsBtnLogin = false;
                    IsBtnQA = false;
                    IsBtnQC = false;
                    IsBtnHT = true;
                    IsBtnSV = false;
                    Login = "ĐĂNG XUẤT";
                    User = "Nguyen My Nhi";
                    break;              
            }
        }
    }
}

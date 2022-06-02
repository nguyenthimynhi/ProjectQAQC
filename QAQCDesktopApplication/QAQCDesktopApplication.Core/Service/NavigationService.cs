using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using QAQCDesktopApplication.Core.Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAQCDesktopApplication.Core.ViewModel;
using QAQCDesktopApplication.Core.ViewModel.History;

namespace QAQCDesktopApplication.Core.Service
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
        public void SelectViewModel()
        {
            switch (_createViewModel)
            {
                case Func<LoginViewModel>:
                    _navigationStore.SelectButton = 1;
                    break;
                case Func<MainQAViewModel>:
                    _navigationStore.SelectButton = 2;
                    break;
                case Func<MainQCViewModel >:
                    _navigationStore.SelectButton = 3;
                    break;
                case Func<SuperviseViewModel>:
                    _navigationStore.SelectButton = 4;
                    break;
                case Func<EditHistoryViewModel>:
                    _navigationStore.SelectButton = 5;
                    break;
                default:
                    _navigationStore.SelectButton = 0;
                    break;
            }
        }
    }
}


using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using QAQCDesktopApplication.Core.Service.Interface;

namespace QAQCDesktopApplication.Core.ViewModel.ViewModelBase
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
            _navigationService.SelectViewModel();
        }
    }
}

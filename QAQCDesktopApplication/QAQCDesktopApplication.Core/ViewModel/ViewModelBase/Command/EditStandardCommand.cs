using QAQCDesktopApplication.Commands;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.QAViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QAQCDesktopApplication.Core.ViewModel.ViewModelBase
{
    public class EditStandardCommand : CommandBase
    {
        private readonly MainQAViewModel _editStandardViewModel;
        private readonly DetailStandardStore _standardStore;
        private readonly INavigationService _navigationService;
        private ApiService _apiservice;

        public EditStandardCommand(MainQAViewModel qaStandardViewModel, DetailStandardStore standardStore, INavigationService navigationService)
        {
            _editStandardViewModel = qaStandardViewModel;
            _standardStore = standardStore;
            _navigationService = navigationService;
        }

        public AddStandardViewModel AddStandardViewModel { get; }
        public DetailStandardStore StandardStore { get; }
        public INavigationService QANavigation { get; }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
            string idstandard = _editStandardViewModel.Selected.id;
            string filename = _editStandardViewModel.Selected.fileName;
            Product product = _editStandardViewModel.Selected.product;
            DateTime upload = DateTime.Now;
            ObservableCollection<AppearanceError> appearanceerror = _editStandardViewModel.Selected.appearanceErrors;
            ObservableCollection<Dimension> dimension = _editStandardViewModel.Selected.dimensions;
            _standardStore.EditStandard(idstandard, filename, product, upload, appearanceerror, dimension);                      
            _navigationService.Navigate();           
        }
    }
}

using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel.History
{
    public class EditHistoryViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private ObservableCollection<EditHistory> _historyEdit;
        public ObservableCollection<EditHistory> historyEdit {get { return _historyEdit; } set { _historyEdit = value; OnPropertyChanged(nameof(historyEdit)); } }
        public DateTime startDate { get; set; }
        public DateTime stopDate { get; set; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand ReportCommand { get; set; }
        public ICommand ViewCommand { get; set; }
        private readonly IDatabaseService _databaseService;

        public EditHistoryViewModel(NavigationStore navigation,INavigationService ReportNavigation, IDatabaseService databaseService)
        {
            _navigationStore = navigation;
            historyEdit = new ObservableCollection<EditHistory>();
            ViewCommand = new RelayCommand(async () => await Task.Run(() => View()));
            ReportCommand = new NavigateCommand(ReportNavigation);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _databaseService = databaseService;
            startDate = DateTime.Today;
            stopDate = DateTime.Today;
        }

        private async void View()
        {
            //editHistory = new EditHistory { User = "Nguyen My Nhi", IsDeleted = true, Date = DateTime.Now, ProductId = Selected.product.id };
            var listhistory = await _databaseService.LoadEditHistory(startDate, stopDate);
            historyEdit = new ObservableCollection<EditHistory>(listhistory); 

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
    }
}

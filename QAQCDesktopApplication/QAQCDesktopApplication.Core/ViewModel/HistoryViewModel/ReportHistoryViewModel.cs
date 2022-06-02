using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using QAQCDesktopApplication.Core.Domain.Model;

namespace QAQCDesktopApplication.Core.ViewModel.History
{
    public class ReportHistoryViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand EditCommand { get; set; }
        public ICommand ViewCommand { get; set; }
        private readonly IDatabaseService _databaseService;
        private ObservableCollection<ReportHistory> _historyReport;
        public ObservableCollection<ReportHistory> historyReport { get { return _historyReport; } set { _historyReport = value; OnPropertyChanged(nameof(historyReport)); } }
        public DateTime startDate { get; set; }
        public DateTime stopDate { get; set; }

        public ReportHistoryViewModel(NavigationStore navigation, INavigationService EditNavigation, IDatabaseService databaseService)
        {
            _navigationStore = navigation;
            EditCommand = new NavigateCommand(EditNavigation);
            ViewCommand = new RelayCommand(async () => await Task.Run(() => View()));
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _databaseService = databaseService;
            startDate = DateTime.Today;
            stopDate = DateTime.Today;
        }

        private async void View()
        {
            //editHistory = new EditHistory { User = "Nguyen My Nhi", IsDeleted = true, Date = DateTime.Now, ProductId = Selected.product.id };
            var listhistory = await _databaseService.LoadReportHistory(startDate, stopDate);
            historyReport = new ObservableCollection<ReportHistory>(listhistory);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

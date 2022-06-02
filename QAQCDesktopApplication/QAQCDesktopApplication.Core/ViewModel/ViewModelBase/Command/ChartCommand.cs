using QAQCDesktopApplication.Commands;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.ViewModel.ViewModelBase.Command
{
    public class ChartCommand : CommandBase
    {
        private readonly MainQCViewModel _qcViewModel;
        //private readonly INavigationService _navigationService;
        private readonly ReporrtStore _store;
        public class ReporrtStore
        {
            public Action<ObservableCollection<qcreport>> ReportChart;
            public void Chart(ObservableCollection<qcreport> qcreports)
            {
                ReportChart.Invoke(qcreports);
            }
        }
        public ChartCommand(MainQCViewModel qcViewModel, ReporrtStore Store)
        {
            _qcViewModel = qcViewModel;
            _store = Store;
        }
        //public AddStandardViewModel AddStandardViewModel { get; }
        public override void Execute(object parameter)
        {
            ObservableCollection<qcreport> report = _qcViewModel.ReportQC;
            _store.Chart(report);
        }
       
    }
}

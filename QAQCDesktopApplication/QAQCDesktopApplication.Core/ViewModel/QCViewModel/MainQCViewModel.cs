using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows;
using QAQCDesktopApplication.Core.ViewModel.QCViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System.Threading;

namespace QAQCDesktopApplication.Core.ViewModel
{
    public class MainQCViewModel : BaseViewModel
    {
        #region properrty
        private bool _isDialogOpen = false;
        public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(nameof(IsDialogOpen)); } }
        private qcreport _current;
        public qcreport Selected { get { return _current; } set { _current = value; OnPropertyChanged(nameof(Selected)); } }

        private string _id = null;
        public string ID { get { return _id; } set { _id = value; OnPropertyChanged(nameof(ID)); } }
        private DateTime _startdate = DateTime.Today;
        public DateTime StartDate { get { return _startdate; } set { _startdate = value; OnPropertyChanged(nameof(StartDate)); } }
        private DateTime _stopdate = DateTime.Today;
        public DateTime StopDate { get { return _stopdate; } set { _stopdate = value; OnPropertyChanged(nameof(StopDate)); } }
        private string _iditem;
        public string Iditem { get { return _iditem; } set { _iditem = value; OnPropertyChanged(nameof(Iditem)); } }
        private string _codeitem;
        public string Codeitem { get { return _codeitem; } set { _codeitem = value; OnPropertyChanged(nameof(Codeitem)); } }
        private string _nameitem;
        public string Nameitem { get { return _nameitem; } set { _nameitem = value; OnPropertyChanged(nameof(Nameitem)); } }
        private string _machineId;
        public string MachineId { get { return _machineId; } set { _machineId = value; OnPropertyChanged(nameof(MachineId)); } }
        private string _moldId;
        public string MoldId { get { return _moldId; } set { _moldId = value; OnPropertyChanged(nameof(MoldId)); } }
        private DateTime _timeitem;
        public DateTime Timeitem { get { return _timeitem; } set { _timeitem = value; OnPropertyChanged(nameof(Timeitem)); } }
        private string _testeritem;
        public string Testeritem { get { return _testeritem; } set { _testeritem = value; OnPropertyChanged(nameof(Testeritem)); } }
        private int _batchitem;
        public int Batchitem { get { return _batchitem; } set { _batchitem = value; OnPropertyChanged(nameof(Batchitem)); } }
        private string _visible = "Hidden";
        public string ReportView { get { return _visible; } set { _visible = value; OnPropertyChanged(nameof(ReportView)); } }
        public ObservableCollection<AppearanceResult> _appearance;
        public ObservableCollection<AppearanceResult> AppearanceResults { get { return _appearance; } set { _appearance = value; OnPropertyChanged(nameof(AppearanceResults)); } }

        private ObservableCollection<DimensionResult> _dimension1;
        public ObservableCollection<DimensionResult> DimensionResult1 { get { return _dimension1; } set { _dimension1 = value; OnPropertyChanged(nameof(DimensionResult1)); } }
        private ObservableCollection<DimensionResult> _dimension2;
        public ObservableCollection<DimensionResult> DimensionResult2 { get { return _dimension2; } set { _dimension2 = value; OnPropertyChanged(nameof(DimensionResult2)); } }
        private ObservableCollection<DimensionResult> _dimension3;
        public ObservableCollection<DimensionResult> DimensionResult3 { get { return _dimension3; } set { _dimension3 = value; OnPropertyChanged(nameof(DimensionResult3)); } }
        private ObservableCollection<DimensionResult> _dimension4;
        public ObservableCollection<DimensionResult> DimensionResult4 { get { return _dimension5; } set { _dimension4 = value; OnPropertyChanged(nameof(DimensionResult4)); } }
        private ObservableCollection<DimensionResult> _dimension5;
        public ObservableCollection<DimensionResult> DimensionResult5 { get { return _dimension5; } set { _dimension5 = value; OnPropertyChanged(nameof(DimensionResult5)); } }
        private List<string> _nameDimension;
        public List<string> NameDimension { get { return _nameDimension; } set { _nameDimension = value; OnPropertyChanged(nameof(NameDimension)); } }

        private List<string> _title;
        public List<string> title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(title)); } }
        private ReportHistory _reportHistory;
        public ReportHistory  reportHistory { get { return _reportHistory; } set { _reportHistory = value; OnPropertyChanged(nameof(reportHistory)); } }
        #endregion 

        public ObservableCollection<qcreport> ReportQC { get => report; set { report = value; } }
        public ObservableCollection<qcreport> report { get; set; }       
        public ICommand ExportCommand { get; set; }
        public ICommand ServerCommand { get; set; }
        public ICommand DetailCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        private bool saveFlag { get; set; }
        private bool serverFlag { get; set; }

        public SeriesCollection Chart { get => _chart; set { _chart = value; OnPropertyChanged(nameof(Chart)); } }
        public SeriesCollection _chart;
        public MessageBoxViewModel MessageBox { get; set; }
        private readonly IDatabaseService _databaseService;
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainQCViewModel(IDatabaseService databaseService)
        {
            //_navigationStore = navigationStore;
            //LoadCommand = new RelayCommand(async () => await Task.Run(() => Load()));
            ReportQC = new ObservableCollection<qcreport>();
            DetailCommand = new RelayCommand(async () => await Task.Run(() => View()));
            ExportCommand = new RelayCommand(async () => await Export());
            ServerCommand = new RelayCommand(async () => await Server());
            _databaseService = databaseService;

            BindingOperations.EnableCollectionSynchronization(ReportQC, Export);
            BindingOperations.EnableCollectionSynchronization(ReportQC, View);
            BindingOperations.EnableCollectionSynchronization(ReportQC, Server);
            MessageBox = new MessageBoxViewModel()
            {
                ContentText = "Bạn có chắc chắc muốn xuất dữ liệu này",
            };
            MessageBox.Cancel += Close;
        }

        private void Close()
        {
            IsDialogOpen = false;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private async Task Export()
        {
            await RunCommandAsync(saveFlag, async () =>
            {
            IsDialogOpen = true;
            MessageBox.Confirm += Open;
                async void Open()
                {
                    IsDialogOpen = false;               
                    ExcelExportService _service1 = new ExcelExportService();
                    var a = await _service1.ExportTest(@"D:\ExcelFile.xlsx", ReportQC);
                    if (Selected != null)
                    {
                        ExportHistory();
                    }
                }
            });
        }
        private async void ExportHistory()
        {
            reportHistory = new ReportHistory { User = "Nguyen My Nhi", Date = DateTime.Now, productId = Selected.standard.product.id, name = Selected.standard.product.name };
            await _databaseService.InsertReportHistory(reportHistory);
        }
        private async Task Server()
        {
            await RunCommandAsync(serverFlag, async () =>
            {
                ReportQC.Clear();
                ApiService _service2 = new ApiService();
                var testReport = await _service2.GetReport(StartDate, StopDate, ID);
                int i = 0;
                foreach (var item1 in testReport.Resource.items)
                {
                    ReportQC.Add(item1);
                    i++;
                }
            });
        }

        private void View()
        {
            ReportView = "Visible";
            if (Selected is qcreport _obj)
            {
                Codeitem = _obj.standard.id;
                MachineId = _obj.machineId;
                MoldId = _obj.moldId;
                Iditem = _obj.standard.product.id;
                Nameitem = _obj.standard.product.name;
                Timeitem = _obj.timestamp;
                Testeritem = _obj.qcTester.lastName + " " + _obj.qcTester.firstName;
                Batchitem = _obj.batchQuantity;
                AppearanceResults = _obj.appearanceResults;
                DimensionResult1 = new ObservableCollection<DimensionResult>();
                DimensionResult2 = new ObservableCollection<DimensionResult>();
                DimensionResult3 = new ObservableCollection<DimensionResult>();
                DimensionResult4 = new ObservableCollection<DimensionResult>();
                DimensionResult5 = new ObservableCollection<DimensionResult>();
                NameDimension = new List<string>();
                title = new List<string>();

                int t = _obj.dimensionResults.Count;
                if (t != 0)
                {
                    switch (_obj.dimensionResults[t - 1].name)
                    {
                        case "A":
                            NameDimension.Add("A");
                            break;
                        case "B":
                            NameDimension.Add("A");
                            NameDimension.Add("B");
                            break;
                        case "C":
                            NameDimension.Add("A");
                            NameDimension.Add("B");
                            NameDimension.Add("C");
                            break;
                        case "D":
                            NameDimension.Add("A");
                            NameDimension.Add("B");
                            NameDimension.Add("C");
                            NameDimension.Add("D");
                            break;
                        case "E":
                            NameDimension.Add("A");
                            NameDimension.Add("B");
                            NameDimension.Add("C");
                            NameDimension.Add("D");
                            NameDimension.Add("E");
                            break;
                        default:
                            break;
                    }
                }
                foreach (DimensionResult item in _obj.dimensionResults)
                {
                    switch (item.name)
                    {
                        case "A":
                            DimensionResult1.Add(item);
                            break;
                        case "B":
                            DimensionResult2.Add(item);
                            break;
                        case "C":
                            DimensionResult3.Add(item);
                            break;
                        case "D":
                            DimensionResult4.Add(item);
                            break;
                        case "E":
                            DimensionResult5.Add(item);
                            break;
                        default:
                            break;
                    }
                }
                foreach (var item in ReportQC)
                {
                    foreach (var appearances in item.appearanceResults)
                    {
                        title.Add(appearances.name);
                    }
                }
                Chart = new SeriesCollection();
                List<string> distinct = title.Distinct().ToList();
                foreach (var item in distinct)
                {
                    var count = title.Count(t => t == item);

                    var task = System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    Chart.Add(new PieSeries() { Title = item, Values = new ChartValues<int> { count }, DataLabels = true })));
                }
            }
        }

    }
}

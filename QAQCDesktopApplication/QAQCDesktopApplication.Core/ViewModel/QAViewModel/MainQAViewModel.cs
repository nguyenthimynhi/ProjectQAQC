using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using PackingMachine.core.ViewModel;
using QAQCDesktopApplication.Core.Domain.DatabaseLocal;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Persistence.Repositories;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.MessageBox;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace QAQCDesktopApplication.Core.ViewModel

{
    public class MainQAViewModel : BaseViewModel
    {
        #region
        public MessageBoxViewModel MessageBox { get; set; }
        public WarningBoxViewModel WarningBox { get; set; }
        public NotifyBoxViewModel NotifyBox { get; set; }
        private bool _isDialogOpen = false;
        public bool isDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(nameof(isDialogOpen)); } }
        private bool _isNotifyDialogOpen;
        public bool IsNotifyDialogOpen { get => _isNotifyDialogOpen; set { _isNotifyDialogOpen = value; OnPropertyChanged(nameof(IsNotifyDialogOpen)); } }
        private bool _isWarningDialogOpen = false;
        public bool IsWarningDialogOpen { get => _isWarningDialogOpen; set { _isWarningDialogOpen = value; OnPropertyChanged(nameof(IsWarningDialogOpen)); } }
        private bool _isEnabled = true;
        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; OnPropertyChanged(nameof(IsEnabled)); } }

        private StandardDetail _selected;
        public StandardDetail Selected { get { return _selected; } set { _selected = value; OnPropertyChanged(nameof(Selected)); } }
        private string filter;
        public string Filter { get { return filter; } set { if (value != filter) { filter = value; viewsource.View.Refresh(); } } }
        private string _nameProduct;
        public string nameProduct { get => _nameProduct; set { _nameProduct = value; OnPropertyChanged(nameof(nameProduct)); } }
        public CollectionViewSource viewsource { get; set; }
        public ICollectionView view { get { return viewsource.View; } }
        private ObservableCollection<StandardDetail> list;
        public ObservableCollection<StandardDetail> StandardList { get => list; set { list = value; OnPropertyChanged(nameof(StandardList)); } }// viewsource.View.Refresh(); } }
        public ObservableCollection<AppearanceError> Errorlist { get; set; }
        public ObservableCollection<Dimension> Dimensionlist { get; set; }
        private EditHistory _editHistory;
        public EditHistory editHistory { get { return _editHistory; } set { _editHistory = value; OnPropertyChanged(nameof(editHistory)); } }
        #endregion

        private DetailStandardStore _pagestore;
        private readonly StandardStore _standardStore;
        private readonly ApiService _apiservice;
        private readonly IDatabaseService _databaseService;
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand AddCommand { get; set; }
        public ICommand DetailCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private List<string> _listproduct;
        public List<string> ListProducts { get => _listproduct; set { _listproduct = value; OnPropertyChanged(nameof(ListProducts)); } }

        public MainQAViewModel(NavigationStore navigationStore, INavigationService addStandardNavigation, INavigationService detailStandardNavigation,  DetailStandardStore detailstandardStore,
                               StandardStore standardStore, ApiService apiService, IDatabaseService databaseService)
        {
            _pagestore = detailstandardStore;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _apiservice = apiService;
            _databaseService = databaseService;

            AddCommand = new NavigateCommand(addStandardNavigation);
            DetailCommand = new EditStandardCommand(this, detailstandardStore, detailStandardNavigation);
            StandardList = new ObservableCollection<StandardDetail>();
            Errorlist = new ObservableCollection<AppearanceError>();
            Dimensionlist = new ObservableCollection<Dimension>();
            ListProducts = new List<string>();
            ListProducts.Add("TC-PQA-0");
            Server();
            BindingOperations.EnableCollectionSynchronization(StandardList, Server);
            DeleteCommand = new RelayCommand(async () => await Task.Run(() => Delete()));
            viewsource = new CollectionViewSource();
            viewsource.Source = this.StandardList;
            viewsource.Filter += ApplyFilter;
            _standardStore = standardStore;
            _standardStore.StandardAdded += AddStandard;
            //try { SetTimer(); } catch {  Console.WriteLine("cann't load data"); }                               
            // Box
            NotifyBox = new NotifyBoxViewModel()
            { ContentText = "Bạn đã gửi dữ liệu thành công"};
            NotifyBox.Cancel += Close;
            MessageBox = new MessageBoxViewModel()
            { ContentText = "Bạn có chắc chắn muốn xóa dữ liệu", Icon = PackIconKind.User, };
            MessageBox.Cancel += Close;
            WarningBox = new WarningBoxViewModel();
            WarningBox.WarningConfirm += WarningConfirm;
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(RebindData);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 20);
            dispatcherTimer.Start();
        }
        private void WarningConfirm()
        {
            IsWarningDialogOpen = false;
        }

        private void Close()
        {
            isDialogOpen = false;
            IsNotifyDialogOpen = false;
        }

        private void Delete()
        {
            isDialogOpen = true;
            MessageBox.Confirm += Confirmdelete;
            async void Confirmdelete()
            {
                if (Selected is StandardDetail _obj)
                {
                    isDialogOpen = false;
                    string idstandard = _obj.id;
                    var result = await _apiservice.DeleteStandard(idstandard);
                    if (result.Success == true)
                    {
                        StandardList.Remove(Selected);
                        DeleteHistory();
                    }
                }
            }
        }
        private async void DeleteHistory()
        {
            editHistory = new EditHistory { User = "Nguyen My Nhi", IsDeleted = true, Date = DateTime.Now, productId = Selected.product.id, name = Selected.product.name };
            await _databaseService.InsertEditHistory(editHistory);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        //private void RebindData(object sender, EventArgs e)
        //{
        //    OnCurrentViewModelChanged();
        //}
        public override void Dispose()
        {
            base.Dispose();
        }
        void ApplyFilter(object sender, FilterEventArgs e)
        {
            StandardDetail std = (StandardDetail)e.Item;
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            { e.Accepted = true; }
            else
            {
                e.Accepted = std.product.id.ToLower().Contains(Filter.ToLower()) || std.product.name.ToLower().Contains(Filter.ToLower()) || std.id.ToLower().Contains(Filter.ToLower());
            }
        }

        private async void AddStandard(string idstandard, string fileName, string productid, DateTime uploadDate, ObservableCollection<AppearanceError> appearance, ObservableCollection<Dimension> dimension)
        {
            IsNotifyDialogOpen = true;
            var service = await _apiservice.GetProduct();
            if (productid != null)
            {
                foreach (var item in service.Resource.items)
                {
                    if (item.id == productid)
                    {
                        nameProduct = item.name;
                    }
                }
            }
            StandardList.Add(new StandardDetail(idstandard, fileName, new Product(productid, nameProduct), uploadDate, appearance, dimension));
        }
        private async void Server()
        {
            var list = await _apiservice.GetStandard();
            if (list.Error == null)
            {
                foreach (var item2 in list.Resource)
                {
                    StandardList.Add(item2);
                }
                IsEnabled = true;
            }
            else
            {
                WarningBox.ContentText = "Chưa kết nối được dữ liệu từ máy chủ";
                IsWarningDialogOpen = true;
                IsEnabled = false;
            }
        }
    }
}

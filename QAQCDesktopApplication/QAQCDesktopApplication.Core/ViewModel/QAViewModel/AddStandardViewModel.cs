using Microsoft.Win32;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using QAQCDesktopApplication.Core.Service;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Windows.Threading;
using System.ComponentModel;

namespace QAQCDesktopApplication.Core.ViewModel.QAViewModel
{
    public class AddStandardViewModel : BaseViewModel
    {
        public DateTime Upload = DateTime.Now;
        private string _item;
        private string _id = "TC-PQA-";
        private string _code;
        private string _name;
        private string _text;
        private int _index;
        private string _namedimension { get; set; }
        private double _upperbound { get; set; }
        private double _lowerbound { get; set; }
        public string AddItem { get => _item; set { _item = value; OnPropertyChanged(nameof(AddItem)); } }
        public string TextFile { get => _text; set { _text = value; OnPropertyChanged(nameof(TextFile)); } }
        public string fileBytes { get; set; }
        public byte[] pathPDF { get; set; }
        public byte[] pathImage { get; set; }
        public ImageError imageerror { get; set; }
        public int SelectedIndex { get => _index; set { _index = value; OnPropertyChanged(nameof(SelectedIndex)); } }
        public string IdStandard { get => _id; set { _id = value; OnPropertyChanged(nameof(IdStandard)); } }
        public string IdProduct { get => _code; set { _code = value; OnPropertyChanged(nameof(IdProduct)); } }
        public string NameProduct { get => _name; set { _name = value; OnPropertyChanged(nameof(NameProduct)); } }
        public string Namedimension { get => _namedimension; set { _namedimension = value; OnPropertyChanged(nameof(Namedimension)); } }
        public double Upperbound { get => _upperbound; set { _upperbound = value; OnPropertyChanged(nameof(Upperbound)); } }
        public double Lowerbound { get => _lowerbound; set { _lowerbound = value; OnPropertyChanged(nameof(Lowerbound)); } }

        private bool saveFlag { get; set; }
        private Product _product;
        public Product Products { get => _product; set { _product = value; OnPropertyChanged(nameof(Products)); } }
        private List<string> _listproduct;
        public List<string> ListProducts { get => _listproduct; set { _listproduct = value; OnPropertyChanged(nameof(ListProducts)); } }
        private ObservableCollection<AppearanceError> _error;
        public ObservableCollection<AppearanceError> Itemss { get => _error; set { _error = value; OnPropertyChanged(nameof(Itemss)); } }
        private AppearanceError _item1;
        public AppearanceError Selected { get => _item1; set { _item1 = value; OnPropertyChanged(nameof(Selected)); } }
        private ObservableCollection<Dimension> _dimension;
        public ObservableCollection<Dimension> Dimensions { get => _dimension; set { _dimension = value; OnPropertyChanged(nameof(Dimensions)); } }
        public CollectionViewSource viewsource { get; set; }
        public ICollectionView view { get { return viewsource.View; } }

        private readonly NavigationStore _navigationStore;
        private readonly StandardStore _standardStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand CloseCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand OpenFileCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ImageCommand { get; }

        public AddStandardViewModel(NavigationStore navigationStore, INavigationService QANavigation, StandardStore standardStore)
        {
            _navigationStore = navigationStore;
            CloseCommand = new NavigateCommand(QANavigation);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _standardStore = standardStore;
            SaveCommand = new AddStandardCommand(this, standardStore, QANavigation);
            OpenFileCommand = new RelayCommand(async () => await View());
            ListProducts = new List<string>();
            imageerror = new ImageError(IdStandard, SelectedIndex, pathImage);
            Itemss = new ObservableCollection<AppearanceError>();
            Dimensions = new ObservableCollection<Dimension>();
            LoadCommand = new RelayCommand(async () => await Task.Run(() => GetProducts()));
            InsertCommand = new RelayCommand(async () => await Task.Run(() => Insert()));
            AddCommand = new RelayCommand(async () => await Task.Run(() => Add()));
            ImageCommand = new RelayCommand(async () => await Task.Run(() => AddImage()));
            DeleteCommand = new RelayCommand(async () => await Task.Run(() => Deleteitem()));
            RemoveCommand = new RelayCommand(async () => await Task.Run(() => RemoveItem()));

            BindingOperations.EnableCollectionSynchronization(Itemss, Add);
            BindingOperations.EnableCollectionSynchronization(Itemss, Deleteitem);
            BindingOperations.EnableCollectionSynchronization(Dimensions, RemoveItem);
            BindingOperations.EnableCollectionSynchronization(Dimensions, Insert);
            BindingOperations.EnableCollectionSynchronization(Itemss, AddImage);

            viewsource = new CollectionViewSource();
            viewsource.Source = this.Itemss;
            GetProducts();
        }

        private async void GetProducts()
        {
            ApiService _apiservice = new ApiService();
            var service = await _apiservice.GetProduct();
            if (IdProduct != null)
            {
                foreach (var item in service.Resource.items)
                {
                    if (item.id == IdProduct)
                    {
                        NameProduct = item.name;
                    }
                }
            }
            else
            {
                foreach (var item in service.Resource.items)
                {
                    ListProducts.Add(item.id);
                }
            }  
        }        
        private void Insert()
        {
            Dimensions.Add(new Dimension(Namedimension, Upperbound, Lowerbound));
            Namedimension = "";
            Upperbound = 0;
            Lowerbound = 0;
        }
        private void RemoveItem()
        {
            Dimensions.Clear();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private async Task View()
        {
            await RunCommandAsync(saveFlag, async () =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                //dialog.InitialDirectory = @"D:\",  
                dialog.Filter = "PDF File |*.pdf|All files |*.*";
                dialog.FilterIndex = 1;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == true)
                {
                    TextFile = dialog.FileName;
                    pathPDF = File.ReadAllBytes(TextFile);
                    fileBytes = Convert.ToBase64String(pathPDF);
                }
            });
        }
        
        private void Add()
        {
            Itemss.Add(new AppearanceError(AddItem));
            AddItem = "";      
        }
        private void Deleteitem()
        {
            Itemss.Clear();
        }
        private void AddImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"D:\Error";
            dialog.Filter = "JPG File |*.jpg|All files |*.*";
            dialog.FilterIndex = 1;
            imageerror.appearanceErrorIndex = SelectedIndex;
            imageerror.standardId = IdStandard;

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                pathImage = File.ReadAllBytes(path);
                imageerror.fileData = pathImage;
            }
        }
       
        //protected void RebindData(object sender, EventArgs e)
        //{
        //    if (IsDelete == true)
        //    {
        //        Itemss.Remove(Seleteditem);
        //    }
        //}
        //private void SetTimer()
        //{
        //    DispatcherTimer dispatcherTimer = new DispatcherTimer();
        //    dispatcherTimer.Tick += new EventHandler(RebindData);
        //    dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        //    dispatcherTimer.Start();
        //}
    }
}

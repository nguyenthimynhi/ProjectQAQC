using Mono.Cecil;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.MessageBox;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel.QAViewModel
{
    public class DetailStandardViewModel :BaseViewModel
    {
        private string id;
        private string code;
        private string _name;
        private string _file;
        private StandardDetail _standard;
        private Product _product;
        public string IdStandard { get => id; set { id = value; OnPropertyChanged(nameof(IdStandard)); } }
        public string IdProduct { get => code; set { code = value; OnPropertyChanged(nameof(IdProduct)); } }
        public string NameProduct { get => _name; set { _name = value; OnPropertyChanged(nameof(NameProduct)); } }
        public string FileName { get => _file; set { _file = value; OnPropertyChanged(nameof(FileName)); } }
        private ObservableCollection<AppearanceError> list1;
        public ObservableCollection<AppearanceError> AppearanceList { get => list1; set { list1 = value; } }
        private ObservableCollection<Dimension> list2;
        public ObservableCollection<Dimension> DimensionList { get => list2; set { list2 = value; } }
        public StandardDetail Standarditem { get => _standard; set { _standard = value; OnPropertyChanged(nameof(Standarditem)); } }
        public Product Productitem { get => _product; set { _product = value; OnPropertyChanged(nameof(Productitem)); } }
        public MessageBoxViewModel MessageBox { get; set; }
        public NotifyBoxViewModel NotifyBox { get; set; }
        private bool _isDialogOpen = false;
        public bool isDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(nameof(isDialogOpen)); } }

        private readonly NavigationStore _navigationStore;
        private readonly DetailStandardStore _standardStore;
        private readonly ApiService _apiservice;
        private bool saveFlag { get; set; }
        private string _tempFile;
        public string tempFile { get => _tempFile; set { _tempFile = value; OnPropertyChanged(nameof(tempFile)); } }
        private Uri _source;
        public Uri source { get => _source; set { _source = value; OnPropertyChanged(nameof(source)); } }

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand CloseCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public DetailStandardViewModel(NavigationStore navigationStore, INavigationService QANavigation, DetailStandardStore standardStore, ApiService apiService)
        {
            _navigationStore = navigationStore;
            CloseCommand = new NavigateCommand(QANavigation);
            SaveCommand = new NavigateCommand(QANavigation);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _standardStore = standardStore;
            _standardStore.StandardEdited += StandardEdit;
            _apiservice = apiService;
            //DeleteCommand = new RelayCommand(async () => await Task.Run(() => Delete()));
            MessageBox = new MessageBoxViewModel()
            { ContentText = "Bạn có chắc chắn muốn xóa dữ liệu"};
            MessageBox.Cancel += Close;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void Close()
        {
            isDialogOpen = false;
        }

       
        private async void StandardEdit(string idstandard, string fileName, Product product, DateTime uploadDate, ObservableCollection<AppearanceError> appearance, ObservableCollection<Dimension> dimension)
        {
            await RunCommandAsync(saveFlag, async () =>
            {
            Standarditem = new StandardDetail(idstandard, fileName, product, uploadDate, appearance, dimension);
                IdStandard = Standarditem.id;
                FileName = Standarditem.fileName;
                Productitem = Standarditem.product;
                AppearanceList = Standarditem.appearanceErrors;
                DimensionList = Standarditem.dimensions;
                Server();
                tempFile = @"D:\a - Copy.pdf";
                source = new Uri(tempFile);
            });
        }
        private async void Server()
        {
            var service = await _apiservice.GetFiles(IdStandard);
            if (service.Error == null)
            {
                //var fileBytes = Convert.FromBase64String(service.Resource.fileData);
                var fileBytes = service.Resource.fileData;
                File.WriteAllBytes(@"D:\a.pdf", fileBytes);
                await Task.Delay(9000);
                tempFile = @"D:\a.pdf";
                source = new Uri(tempFile);
            }
            else if (service.Success == false)
            {
                source = new Uri(FileName);
            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    
    }
}

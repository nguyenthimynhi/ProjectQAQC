using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel
{
    public class SuperviseViewModel : BaseViewModel
    {
        public ObservableCollection<Machine> report { get; set; }
        public ObservableCollection<Machine> Report { get => report; set { report = value; } }
        private string filter;
        public string Filter { get { return filter; } set { if (value != filter) { filter = value; viewsource.View.Refresh(); } } }
        public CollectionViewSource viewsource { get; set; }
        public ICollectionView view { get { return viewsource.View; } }
        public ICommand ExportCommand { get; set; }
        public ICommand ImportCommand { get; set; }
        public MessageBoxViewModel MessageBox { get; set; }
        private bool _isDialogOpen = false;
        public bool IsDialogOpen { get => _isDialogOpen; set { _isDialogOpen = value; OnPropertyChanged(nameof(IsDialogOpen)); } }
        private bool saveFlag { get; set; }

        public SuperviseViewModel()
        {
            Report = new ObservableCollection<Machine>();
            ImportCommand = new RelayCommand(async () => await Import());
            ExportCommand = new RelayCommand(async () => await Export());
            viewsource = new CollectionViewSource();
            viewsource.Source = this.Report;
            viewsource.Filter += ApplyFilter;
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
        private async Task Import()
        {
            Report.Clear();
            await RunCommandAsync(saveFlag, async () =>
            {
                ImportExcelService _service1 = new ImportExcelService();
                await _service1.Import(Report);
            });
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
                    ImportExcelService _service2 = new ImportExcelService();
                    var a = await _service2.Export(Report);   
                }
            });
        }
        void ApplyFilter(object sender, FilterEventArgs e)
        {
            Machine std = (Machine)e.Item;
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            { e.Accepted = true; }
            else
            {
                e.Accepted = std.ID.ToLower().Contains(Filter.ToLower()) || std.moldId.ToLower().Contains(Filter.ToLower()) || std.product.id.ToLower().Contains(Filter.ToLower());
            }
        }
    }
}

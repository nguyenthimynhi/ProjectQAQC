using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows;
using System.Windows.Input;

namespace QAQCDesktopApplication.Core.ViewModel.QCViewModel
{
    public class ChartViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        //public SeriesCollection Chart { get => _chart; set { _chart = value; OnPropertyChanged(nameof(Chart)); } }
        public SeriesCollection _chart;
        public List<string> tille;
        //public static Report Selected { get; set; }
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand CloseCommand { get; }
        //public ChartViewModel()
        //{
            //Chart = new SeriesCollection();
            //Chart.Add(new PieSeries() { Title = "nứt vỡ", Values = new ChartValues<int> { 100 }, DataLabels = true });
            //Chart.Add(new PieSeries() { Title = "biến dạng, cong vênh", Values = new ChartValues<int> { 200 }, DataLabels = true });
            //Chart.Add(new PieSeries() { Title = "loan màu, lẫn màu", Values = new ChartValues<double> { 300 }, DataLabels = true });
        //}
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

using QAQCDesktopApplication.Core.ViewModel.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Model
{
    public class StandardDetail
    {
        private string _id;
        private string _filename;
        private Product _product;
        private ObservableCollection<AppearanceError> _error;
        private ObservableCollection<Dimension> _dimension;
        public string id { get => _id; set { _id = value; OnPropertyChanged(nameof(id)); } }
        public string fileName { get => _filename; set { _filename = value; OnPropertyChanged(nameof(fileName)); } }
        public DateTime uploadDate { get; set; }
        public ObservableCollection<AppearanceError>? appearanceErrors { get => _error; set { _error = value; OnPropertyChanged(nameof(appearanceErrors)); } }
        public ObservableCollection<Dimension>? dimensions { get => _dimension; set { _dimension = value; OnPropertyChanged(nameof(dimensions)); } }
        public Product product { get => _product; set { _product = value; OnPropertyChanged(nameof(product)); } }

        public StandardDetail(string Id, string FileName, Product Product, DateTime UploadDate, ObservableCollection<AppearanceError> Appearance, ObservableCollection<Dimension>? Dimensions)
        {
            id = Id;
            fileName = FileName;
            product = Product;
            uploadDate = UploadDate;
            appearanceErrors = Appearance;
            dimensions = Dimensions;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

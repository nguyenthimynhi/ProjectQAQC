using Microsoft.AspNetCore.Http;
using QAQCDesktopApplication.Commands;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel.QAViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.ViewModel.ViewModelBase
{
    internal class AddStandardCommand : CommandBase
    {
        private readonly AddStandardViewModel _addStandardViewModel;
        private readonly StandardStore _standardStore;
        private readonly INavigationService _navigationService;
        private filePDF _file;
        public filePDF file { get => _file; set { _file = value; } }

        public AddStandardCommand(AddStandardViewModel addStandardViewModel, StandardStore standardStore, INavigationService navigationService)
        {
            _addStandardViewModel = addStandardViewModel;
            _standardStore = standardStore;
            _navigationService = navigationService;
        }

        public AddStandardViewModel AddStandardViewModel { get; }
        public StandardStore StandardStore { get; }

        public override void Execute(object parameter)
        {
            var filebyte = _addStandardViewModel.pathPDF;
            ImageError imageError = _addStandardViewModel.imageerror;
            string idstandard = _addStandardViewModel.IdStandard;
            string filename = _addStandardViewModel.TextFile;
            string product = _addStandardViewModel.IdProduct; //không null
            DateTime upload = _addStandardViewModel.Upload;
            ObservableCollection<AppearanceError> appearanceerror = _addStandardViewModel.Itemss;
            ObservableCollection<Dimension> dimension = _addStandardViewModel.Dimensions;
            ApiService _apiservice = new ApiService();
            Server();

            async Task Server()
            {
                var post = await _apiservice.PostStandard(new Standard(idstandard, filename, product, upload, appearanceerror, dimension));
                _standardStore.AddStandard(idstandard, filename, product, upload, appearanceerror, dimension);
                filePDF file = new filePDF(idstandard, filebyte);
                if (post.Error == null)
                {
                    await _apiservice.PutFiles(file);
                    await _apiservice.PutImage(imageError);
                }
                _navigationService.Navigate();
            }
        }
    }
}

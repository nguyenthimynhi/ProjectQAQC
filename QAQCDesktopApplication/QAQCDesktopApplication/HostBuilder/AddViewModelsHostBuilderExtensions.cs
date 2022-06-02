using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel;
using QAQCDesktopApplication.Core.ViewModel.History;
using QAQCDesktopApplication.Core.ViewModel.QAViewModel;
using QAQCDesktopApplication.Core.ViewModel.QCViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.HostBuilder
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddTransient<LoginViewModel> ((IServiceProvider serviceprovider) =>
                {
                    var store = serviceprovider.GetRequiredService<NavigationStore>();
                    return new LoginViewModel(store, CreateQAViewNavigationService(serviceprovider, store));
                });
                services.AddSingleton<ChartViewModel>();
                services.AddSingleton<SuperviseViewModel>();
                services.AddSingleton<EditHistoryViewModel>((IServiceProvider serviceprovider) =>
                {
                    var EHstore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new EditHistoryViewModel(EHstore, CreateRHistoryNavigationService(serviceprovider, EHstore), serviceprovider.GetRequiredService<IDatabaseService>());
                });
                services.AddSingleton<ReportHistoryViewModel>((IServiceProvider serviceprovider) =>
                {
                    var RHstore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new ReportHistoryViewModel(RHstore, CreateEHistoryNavigationService(serviceprovider, RHstore), serviceprovider.GetRequiredService<IDatabaseService>());
                });

                services.AddSingleton<DetailStandardViewModel>((IServiceProvider serviceprovider) =>
                {
                    var DSstore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new DetailStandardViewModel(DSstore, CreateQAViewNavigationService(serviceprovider, DSstore), serviceprovider.GetRequiredService<DetailStandardStore>(), serviceprovider.GetRequiredService<ApiService>());
                });
                services.AddTransient<AddStandardViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Addstore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new AddStandardViewModel(Addstore, CreateQAViewNavigationService(serviceprovider, Addstore), serviceprovider.GetRequiredService<StandardStore>());
                });
                services.AddTransient<MainQAViewModel>((IServiceProvider serviceprovider) =>
                {
                    var QAstore = serviceprovider.GetRequiredService<NavigationStore>();
                    var DSstore = serviceprovider.GetRequiredService<DetailStandardStore>();
                    services.AddTransient<AddStandardViewModel>(s => new AddStandardViewModel(QAstore, CreateQAViewNavigationService(serviceprovider, QAstore), s.GetRequiredService<StandardStore>()));
                    services.AddSingleton<DetailStandardViewModel>(s => new DetailStandardViewModel(QAstore, CreateQAViewNavigationService(serviceprovider, QAstore), DSstore, serviceprovider.GetRequiredService<ApiService>()));
                    return new MainQAViewModel(QAstore, CreateAddStandardNavigationService(serviceprovider, QAstore), CreateDetailStandardNavigationService(serviceprovider, QAstore),
                        DSstore, serviceprovider.GetRequiredService<StandardStore>(), serviceprovider.GetRequiredService<ApiService>(), serviceprovider.GetRequiredService<IDatabaseService>());
                });
                services.AddSingleton<MainQCViewModel>((IServiceProvider serviceprovider) =>
                {
                    var QCstore = serviceprovider.GetRequiredService<NavigationStore>();
                    return new MainQCViewModel(serviceprovider.GetRequiredService<IDatabaseService>());
                });
                services.AddSingleton<MainViewModel>((IServiceProvider serviceprovider) =>
                {
                    var Mainstore = serviceprovider.GetRequiredService<NavigationStore>();
                    Mainstore.CurrentViewModel = serviceprovider.GetRequiredService<LoginViewModel>();
                    return new MainViewModel(Mainstore, CreateLoginNavigationService(serviceprovider, Mainstore), CreateQAViewNavigationService(serviceprovider, Mainstore), 
                        CreateQCViewNavigationService(serviceprovider, Mainstore), CreateSupervidseNavigationService(serviceprovider, Mainstore), CreateEHistoryNavigationService(serviceprovider, Mainstore));
                });
            });

            return host;
        }

        private static INavigationService CreateEHistoryNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<EditHistoryViewModel>(store,
                () => serviceProvider.GetRequiredService<EditHistoryViewModel>());
        }

        private static INavigationService CreateRHistoryNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<ReportHistoryViewModel>(store,
                () => serviceProvider.GetRequiredService<ReportHistoryViewModel>());
        }

        private static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<LoginViewModel>(store,
                () => serviceProvider.GetRequiredService<LoginViewModel>());
        }
        private static INavigationService CreateQAViewNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<MainQAViewModel>(store,
                () => serviceProvider.GetRequiredService<MainQAViewModel>());
        }
        private static INavigationService CreateQCViewNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<MainQCViewModel>(store,
            () => serviceProvider.GetRequiredService<MainQCViewModel>());
        }
        private static INavigationService CreateAddStandardNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<AddStandardViewModel>(store,
            () => serviceProvider.GetRequiredService<AddStandardViewModel>());
        }
        private static INavigationService CreateDetailStandardNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<DetailStandardViewModel>(store,
            () => serviceProvider.GetRequiredService<DetailStandardViewModel>());
        }
        private static INavigationService CreateChartVewNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<ChartViewModel>(store,
            () => serviceProvider.GetRequiredService<ChartViewModel>());
        }
        private static INavigationService CreateSupervidseNavigationService(IServiceProvider serviceProvider, NavigationStore store)
        {
            return new NavigationService<SuperviseViewModel>(store,
            () => serviceProvider.GetRequiredService<SuperviseViewModel>());
        }
    }
}

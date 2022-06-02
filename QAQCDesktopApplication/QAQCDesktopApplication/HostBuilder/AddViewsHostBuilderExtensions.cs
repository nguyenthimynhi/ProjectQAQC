using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.ViewModel;
using QAQCDesktopApplication.Core.ViewModel.QAViewModel;
using QAQCDesktopApplication.View.QAView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.HostBuilder
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)     
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });
            return host;

        }
    }
}

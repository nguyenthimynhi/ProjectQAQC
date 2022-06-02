using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QAQCDesktopApplication.Core.Service.Interface;
using QAQCDesktopApplication.Core.Service;
using QAQCDesktopApplication.Core.Domain.Store;
using QAQCDesktopApplication.HostBuilder;
using QAQCDesktopApplication.Core.Persistence.Repositories;
using QAQCDesktopApplication.Core.Domain.Persistence.Repositories;

namespace QAQCDesktopApplication.HostBuilder
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>

            {
                services.AddSingleton<StandardStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<DetailStandardStore>();
                services.AddSingleton<ApiService>();
                services.AddSingleton<IDatabaseService, DatabaseService>();
                services.AddSingleton<IReportHistoryRepository, ReportHistoryRepository>();
                services.AddSingleton<IEditHistoryRepository, EditHistoryRepository>();
                services.AddSingleton<IUnitOfWork, UnitOfWork>();
            });
            return host;
        }
    }
}

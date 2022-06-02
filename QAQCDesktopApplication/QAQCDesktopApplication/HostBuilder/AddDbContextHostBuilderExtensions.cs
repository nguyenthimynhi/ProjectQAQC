using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.HostBuilder
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddDbContextFactory<ApplicationDbContext>();
            });
            return host;
        }
    }
}

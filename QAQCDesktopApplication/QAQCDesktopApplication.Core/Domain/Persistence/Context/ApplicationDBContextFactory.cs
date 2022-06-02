using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Persistence.Context
{
    public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlite(@"Data Source=D:\CHA_QAQC-develop\QAQCDesktopApplication\QAQCDesktopApplication\bin\Debug\net6.0-windows\QAQCDesktopApplicationHistory.db");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}

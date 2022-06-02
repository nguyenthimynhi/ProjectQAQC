using Microsoft.EntityFrameworkCore;
using QAQCDesktopApplication.Core.Domain.DatabaseLocal;
using QAQCDesktopApplication.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<ProductDatabase> product { get; set; }
        public DbSet<EditHistory> editHistory { get; set; }
        public DbSet<ReportHistory> reportHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=QAQCDesktopApplicationHistory.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductDatabase>()
            //   .HasKey(k => k.ID);
            modelBuilder.Entity<EditHistory>()
               .HasKey(k => k.Id);

            //modelBuilder.Entity<EditHistory>()
            //            .HasOne<ProductDatabase>(ad => ad.Product)
            //            .WithOne(s => s.editHistory)
            //            .HasForeignKey<EditHistory>(ad => ad.ProductId);
            modelBuilder.Entity<ReportHistory>()
               .HasKey(k => k.Id);
            //modelBuilder.Entity<ReportHistory>()
            //           .HasOne<ProductDatabase>(ad => ad.Product)
            //           .WithOne(s => s.reportHistory)
            //           .HasForeignKey<ReportHistory>(ad => ad.ProductId);
            base.OnModelCreating(modelBuilder);
        }
    }
}

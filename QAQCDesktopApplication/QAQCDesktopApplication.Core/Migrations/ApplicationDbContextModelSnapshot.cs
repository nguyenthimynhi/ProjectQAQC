﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;

#nullable disable

namespace QAQCDesktopApplication.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("QAQCDesktopApplication.Core.Domain.DatabaseLocal.ProductDatabase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("editHistoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("productId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("reportHistoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("editHistoryId");

                    b.HasIndex("reportHistoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("QAQCDesktopApplication.Core.Domain.Model.EditHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("User")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("productId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("editHistory");
                });

            modelBuilder.Entity("QAQCDesktopApplication.Core.Domain.Model.ReportHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("productId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("reportHistory");
                });

            modelBuilder.Entity("QAQCDesktopApplication.Core.Domain.DatabaseLocal.ProductDatabase", b =>
                {
                    b.HasOne("QAQCDesktopApplication.Core.Domain.Model.EditHistory", "editHistory")
                        .WithMany()
                        .HasForeignKey("editHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAQCDesktopApplication.Core.Domain.Model.ReportHistory", "reportHistory")
                        .WithMany()
                        .HasForeignKey("reportHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("editHistory");

                    b.Navigation("reportHistory");
                });
#pragma warning restore 612, 618
        }
    }
}

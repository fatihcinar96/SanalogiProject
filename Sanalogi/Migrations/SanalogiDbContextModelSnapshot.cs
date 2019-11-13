﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sanalogi.Models.Data;

namespace Sanalogi.Migrations
{
    [DbContext(typeof(SanalogiDbContext))]
    partial class SanalogiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Sanalogi.Models.InvoiceModel", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<string>("InvoiceNo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .HasMaxLength(25);

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
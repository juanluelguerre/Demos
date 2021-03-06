﻿// <auto-generated />
using System;
using ElGuerre.PowerBI.PerformanceCounters.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElGuerre.PowerBI.PerformanceCounters.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElGuerre.PowerBI.PerformanceCounters.Data.AverageCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AvailableDiskSpaceGB");

                    b.Property<double>("AvailableMemoryGB");

                    b.Property<string>("MachineName");

                    b.Property<double>("ProcessorTime");

                    b.HasKey("Id");

                    b.ToTable("AverageCounters");
                });

            modelBuilder.Entity("ElGuerre.PowerBI.PerformanceCounters.Data.PerfCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AvailableDiskSpaceGB");

                    b.Property<double>("AvailableMemoryGB");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("MachineName");

                    b.Property<double>("ProcessorTime");

                    b.HasKey("Id");

                    b.ToTable("Counters");
                });
#pragma warning restore 612, 618
        }
    }
}

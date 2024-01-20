﻿// <auto-generated />
using System;
using Core.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations.MultiTenantDb
{
    [DbContext(typeof(MultiTenantDbContext))]
    partial class MultiTenantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Furion.DatabaseAccessor.Tenant", b =>
                {
                    b.Property<Guid>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionString")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Host")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Schema")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenant");

                    b.HasData(
                        new
                        {
                            TenantId = new Guid("383afb88-f519-fff8-b364-6d563bf3687f"),
                            ConnectionString = "Data Source=localhost;Initial Catalog=Common;user id=admin;password=Aa123456;TrustServerCertificate=true;Max Pool Size=64; Min Pool Size=5",
                            CreatedTime = new DateTimeOffset(new DateTime(2020, 10, 6, 20, 19, 7, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            Host = "localhost:44313",
                            Name = "默认租户"
                        },
                        new
                        {
                            TenantId = new Guid("c5798cb6-16d6-0f42-eb56-59c695353bc0"),
                            CreatedTime = new DateTimeOffset(new DateTime(2020, 10, 6, 20, 20, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)),
                            Host = "localhost:5000",
                            Name = "其他租户"
                        });
                });

            modelBuilder.Entity("通用订票.Core.Entity.JobCluster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobCluster");
                });

            modelBuilder.Entity("通用订票.Core.Entity.JobDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssemblyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Concurrent")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IncludeAnnotations")
                        .HasColumnType("bit");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobDetail");
                });

            modelBuilder.Entity("通用订票.Core.Entity.JobTrigger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Args")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssemblyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ElapsedTime")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastRunTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("MaxNumberOfErrors")
                        .HasColumnType("bigint");

                    b.Property<long>("MaxNumberOfRuns")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("NextRunTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumRetries")
                        .HasColumnType("int");

                    b.Property<long>("NumberOfErrors")
                        .HasColumnType("bigint");

                    b.Property<long>("NumberOfRuns")
                        .HasColumnType("bigint");

                    b.Property<bool>("ResetOnlyOnce")
                        .HasColumnType("bit");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetryTimeout")
                        .HasColumnType("int");

                    b.Property<bool>("RunOnStart")
                        .HasColumnType("bit");

                    b.Property<bool>("StartNow")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("Status")
                        .HasColumnType("bigint");

                    b.Property<string>("TriggerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TriggerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobTrigger");
                });
#pragma warning restore 612, 618
        }
    }
}

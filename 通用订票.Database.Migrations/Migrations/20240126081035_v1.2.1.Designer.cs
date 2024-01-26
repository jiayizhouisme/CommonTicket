﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using 通用订票.EntityFramework.Core;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    [DbContext(typeof(MyDefaultDbContext))]
    [Migration("20240126081035_v1.2.1")]
    partial class v121
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("通用订票.Core.Entity.Appointment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("day")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("objectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("sale")
                        .HasColumnType("int");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("stockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("objectId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Exhibition", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("basicPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Exhibition");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Order", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("objectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("payedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("trade_no")
                        .HasColumnType("bigint");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("_id");

                    b.HasIndex("trade_no");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Ticket", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("objectId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("stauts")
                        .HasColumnType("int");

                    b.Property<string>("ticketNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("_id");

                    b.HasIndex("objectId");

                    b.HasIndex("TUserId", "startTime", "endTime");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("通用订票.Core.Entity.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("authLevel")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("通用订票.Core.Entity.UserInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("idCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userID");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatBill", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<string>("parameters")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("payTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payedMsg")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("paymentCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("sourceId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("tradeNo")
                        .HasColumnType("bigint");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.ToTable("WechatBill");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Appointment", b =>
                {
                    b.HasOne("通用订票.Core.Entity.Exhibition", "exhibition")
                        .WithMany()
                        .HasForeignKey("objectId")
                        .IsRequired();

                    b.Navigation("exhibition");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Ticket", b =>
                {
                    b.HasOne("通用订票.Core.Entity.UserInfo", "userInfo")
                        .WithMany()
                        .HasForeignKey("TUserId")
                        .IsRequired();

                    b.Navigation("userInfo");
                });

            modelBuilder.Entity("通用订票.Core.Entity.UserInfo", b =>
                {
                    b.HasOne("通用订票.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatBill", b =>
                {
                    b.HasOne("通用订票.Core.Entity.Order", "order")
                        .WithMany()
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });
#pragma warning restore 612, 618
        }
    }
}

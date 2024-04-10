﻿// <auto-generated />
using System;
using Core.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    [DbContext(typeof(MasterDbContext_SQL))]
    [Migration("20240410061848_v20.0")]
    partial class v200
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("通用订票.Core.Entity.Appointment", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

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
                    b.Property<long>("trade_no")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("trade_no"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("extraInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("payedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("trade_no");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Ticket", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OTAPassengerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("itemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("objectId")
                        .HasColumnType("bigint");

                    b.Property<int>("ota")
                        .HasColumnType("int");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("stauts")
                        .HasColumnType("int");

                    b.Property<string>("ticketNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalCount")
                        .HasColumnType("int");

                    b.Property<int>("usedCount")
                        .HasColumnType("int");

                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("userid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userid");

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

                    b.HasIndex("tradeNo");

                    b.ToTable("WechatBill");
                });

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengConfig", b =>
                {
                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AESKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AESVector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account");

                    b.ToTable("XieChengConfig");
                });

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengOrder", b =>
                {
                    b.Property<string>("otaOrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PLU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("cancelQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("itemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("locale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.Property<string>("passengerIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("payedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("trade_no")
                        .HasColumnType("bigint");

                    b.Property<string>("useEndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("useQuantity")
                        .HasColumnType("int");

                    b.Property<string>("useStartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("otaOrderId");

                    b.ToTable("XieChengOrder");
                });

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengPassenger", b =>
                {
                    b.Property<string>("passengerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cardNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nationalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("passengerId");

                    b.ToTable("XieChengPassenger");
                });

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengTicket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("OTAPassengerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticketId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("XieChengTicket");
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
                    b.HasOne("通用订票.OTA.携程.Entity.XieChengTicket", null)
                        .WithOne("ticket")
                        .HasForeignKey("通用订票.Core.Entity.Ticket", "_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("通用订票.Core.Entity.UserInfo", b =>
                {
                    b.HasOne("通用订票.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatBill", b =>
                {
                    b.HasOne("通用订票.Core.Entity.Order", "order")
                        .WithMany()
                        .HasForeignKey("tradeNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengTicket", b =>
                {
                    b.Navigation("ticket")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

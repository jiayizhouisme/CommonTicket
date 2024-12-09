﻿// <auto-generated />
using System;
using Core.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace 通用订票.Database.Migrations.Migrations
{
    [DbContext(typeof(MasterDbContext_SQL))]
    partial class MasterDbContext_SQLModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.User.Entity.WebRouteConfig", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("keyPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("routePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("WebRouteConfig");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Appointment", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("allday")
                        .HasColumnType("bit");

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

                    b.Property<TimeSpan>("endTime")
                        .HasColumnType("time");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("objectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("sale")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("startTime")
                        .HasColumnType("time");

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
                        .HasColumnType("decimal(18,2)")
                        .HasComment("价格");

                    b.Property<int>("beforeDays")
                        .HasColumnType("int")
                        .HasComment("景区提前预约天数");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建日期");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("景区介绍");

                    b.Property<string>("exhibitions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("forbiddenRule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgs")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("景区封面");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isMultiPart")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("景区名");

                    b.Property<int>("passType")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("totalAmount")
                        .HasColumnType("int")
                        .HasComment("一天最大预约人数");

                    b.HasKey("id");

                    b.ToTable("Exhibition");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Introduce", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imgs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TurDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Introduce");
                });

            modelBuilder.Entity("通用订票.Core.Entity.MultiTicket", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cancelCount")
                        .HasColumnType("int")
                        .HasComment("取消数量");

                    b.Property<Guid>("exhibitionId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("景区id");

                    b.Property<string>("ticketNumber")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("票号");

                    b.Property<int>("totalCount")
                        .HasColumnType("int")
                        .HasComment("总数");

                    b.Property<int>("usedCount")
                        .HasColumnType("int")
                        .HasComment("已使用数量");

                    b.HasKey("id");

                    b.HasIndex("ticketNumber");

                    b.ToTable("MultiTicket", t =>
                        {
                            t.HasComment("联票");
                        });
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
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<DateTime>("expireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("extraInfo")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("订单项信息");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("objectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("payedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("trade_no");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("通用订票.Core.Entity.Ticket", b =>
                {
                    b.Property<int>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_id"));

                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("时间段id");

                    b.Property<string>("QRCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("cancelCount")
                        .HasColumnType("int")
                        .HasComment("无效票数量");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isMultiPart")
                        .HasColumnType("bit")
                        .HasComment("是否是联票");

                    b.Property<long>("objectId")
                        .HasColumnType("bigint");

                    b.Property<int>("ota")
                        .HasColumnType("int")
                        .HasComment("服务商类型");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("stauts")
                        .HasColumnType("int");

                    b.Property<string>("ticketNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalCount")
                        .HasColumnType("int")
                        .HasComment("票总数");

                    b.Property<int>("usedCount")
                        .HasColumnType("int")
                        .HasComment("已使用数量");

                    b.Property<long>("userID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("verifyTime")
                        .HasColumnType("datetime2")
                        .HasComment("核销时间");

                    b.HasKey("_id");

                    b.HasIndex("objectId");

                    b.HasIndex("TUserId", "startTime", "endTime");

                    b.ToTable("Ticket", t =>
                        {
                            t.HasComment("门票");
                        });
                });

            modelBuilder.Entity("通用订票.Core.Entity.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<int>("authLevel")
                        .HasColumnType("int")
                        .HasComment("用户权限等级");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("openId")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("微信openid");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User", t =>
                        {
                            t.HasComment("用户信息");
                        });
                });

            modelBuilder.Entity("通用订票.Core.Entity.UserInfo", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2")
                        .HasComment("创建时间");

                    b.Property<string>("idCard")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("身份证");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("姓名");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("手机号");

                    b.Property<long>("userID")
                        .HasColumnType("bigint")
                        .HasComment("用户ID");

                    b.HasKey("id");

                    b.ToTable("UserInfo", t =>
                        {
                            t.HasComment("游客信息");
                        });
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatBill", b =>
                {
                    b.Property<long>("paymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("paymentId"));

                    b.Property<string>("Attach")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("tradeNo")
                        .HasColumnType("bigint");

                    b.Property<string>("transactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("paymentId");

                    b.HasIndex("tradeNo");

                    b.ToTable("WechatBill");
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatBillRefund", b =>
                {
                    b.Property<long>("refundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("refundId"));

                    b.Property<string>("aftersalesId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("createTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("paymentCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("sourceId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("tradeNo")
                        .HasMaxLength(50)
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("updateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("refundId");

                    b.HasIndex("tradeNo");

                    b.ToTable("WechatBillRefund");
                });

            modelBuilder.Entity("通用订票.Core.Entity.WechatMerchantConfig", b =>
                {
                    b.Property<string>("appid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RsaPublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apiKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apiv3Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mchId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("appid");

                    b.ToTable("WechatMerchantConfig");
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

                    b.Property<int>("voucherStatus")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ticketId")
                        .IsUnique();

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

            modelBuilder.Entity("通用订票.OTA.携程.Entity.XieChengTicket", b =>
                {
                    b.HasOne("通用订票.Core.Entity.Ticket", "ticket")
                        .WithOne()
                        .HasForeignKey("通用订票.OTA.携程.Entity.XieChengTicket", "ticketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ticket");
                });
#pragma warning restore 612, 618
        }
    }
}

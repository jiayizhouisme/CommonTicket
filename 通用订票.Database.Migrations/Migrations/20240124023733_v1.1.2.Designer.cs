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
    [Migration("20240124023733_v1.1.2")]
    partial class v112
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

                    b.HasData(
                        new
                        {
                            id = new Guid("c2ca87c0-c0cc-4cd1-ae6f-754c793994d5"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6580),
                            isDeleted = false,
                            name = "展馆0",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("2ca493a0-7f72-4962-a33a-5957bdc940af"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6601),
                            isDeleted = false,
                            name = "展馆1",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("e7345154-7d34-40d8-bccc-5c7dbb03413e"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6603),
                            isDeleted = false,
                            name = "展馆2",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("7ed9ee8d-efe9-4210-9e36-8b72737bacca"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6604),
                            isDeleted = false,
                            name = "展馆3",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("7ea98ca7-027d-41f3-91ca-8349505c61c0"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6606),
                            isDeleted = false,
                            name = "展馆4",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("daa7b5a5-fb14-4ca4-b565-a12a8e2f797b"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6608),
                            isDeleted = false,
                            name = "展馆5",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("01ffea7d-ec6e-4845-abc4-5e42120ddfcf"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6609),
                            isDeleted = false,
                            name = "展馆6",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("0ba445fe-a39d-413d-80dd-f1ad3cc1ccfb"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6610),
                            isDeleted = false,
                            name = "展馆7",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("27ebd34f-4ac5-4de0-a8a4-8d6feb3f4d97"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6614),
                            isDeleted = false,
                            name = "展馆8",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("57144819-40c7-463f-8618-a1f8ac8c96b7"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6616),
                            isDeleted = false,
                            name = "展馆9",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("8e749e3a-d51c-45a0-ad0d-37808aadddb3"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6618),
                            isDeleted = false,
                            name = "展馆10",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("9fa97daf-cf5f-4885-b56b-63824c95a978"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6619),
                            isDeleted = false,
                            name = "展馆11",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("c1008dee-b939-4bbc-a1aa-50824d222bfc"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6620),
                            isDeleted = false,
                            name = "展馆12",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("55fc6fcc-2cb7-4b5c-9328-9dced430112a"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6621),
                            isDeleted = false,
                            name = "展馆13",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("4ea38eaf-ee6f-43ad-92ce-702337655017"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6622),
                            isDeleted = false,
                            name = "展馆14",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("b7748f8e-f668-4d5d-b1da-9f551dc42c30"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6623),
                            isDeleted = false,
                            name = "展馆15",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("4baa66e8-39e8-492b-8952-65833514670e"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6625),
                            isDeleted = false,
                            name = "展馆16",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("86df789a-d76d-43e8-b02a-6d737b661495"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6627),
                            isDeleted = false,
                            name = "展馆17",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("f83d57c0-3fb9-4c1b-aa10-bdf24a1f59d4"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6629),
                            isDeleted = false,
                            name = "展馆18",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("0e7cddd1-67e8-4c42-87f9-9f65d7c3b509"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6630),
                            isDeleted = false,
                            name = "展馆19",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("c6024730-7f2a-4e88-95b1-f09625acb6ce"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6631),
                            isDeleted = false,
                            name = "展馆20",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("21271ca5-7a37-4b99-8867-4f2ab3a98d08"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6632),
                            isDeleted = false,
                            name = "展馆21",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("91ae4874-dc99-4466-9623-636e3959defc"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6633),
                            isDeleted = false,
                            name = "展馆22",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("9a04b635-2fd3-4c3c-be7f-8f6b32ab704c"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6634),
                            isDeleted = false,
                            name = "展馆23",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("e35bfbc0-a008-4c20-8255-c2256443b146"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6636),
                            isDeleted = false,
                            name = "展馆24",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("da634b2e-77de-4f36-a145-e5e261dfe29b"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6638),
                            isDeleted = false,
                            name = "展馆25",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("b80f3432-aa48-4c69-abb1-63c7b00b9e1e"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6639),
                            isDeleted = false,
                            name = "展馆26",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("08e9b02a-658f-45e0-9a47-1edf5c9221e9"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6640),
                            isDeleted = false,
                            name = "展馆27",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("92716418-36ef-47ee-8bf6-15df4228bf2f"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6641),
                            isDeleted = false,
                            name = "展馆28",
                            status = 1
                        },
                        new
                        {
                            id = new Guid("b5b2ce4c-95c6-4f8e-a7a1-b554b5d4e4db"),
                            basicPrice = 10m,
                            createTime = new DateTime(2024, 1, 24, 10, 37, 33, 447, DateTimeKind.Local).AddTicks(6642),
                            isDeleted = false,
                            name = "展馆29",
                            status = 1
                        });
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

                    b.Property<string>("trade_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("objectId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("TUserId");

                    b.HasIndex("objectId");

                    b.HasIndex("startTime", "endTime", "TUserId");

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

                    b.Property<string>("tradeNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

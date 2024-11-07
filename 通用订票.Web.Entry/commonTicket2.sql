USE [CommonTicket2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id] [nvarchar](48) NOT NULL,
	[day] [int] NOT NULL,
	[startTime] [datetime2](7) NOT NULL,
	[endTime] [datetime2](7) NOT NULL,
	[description] [nvarchar](max) NULL,
	[brief] [nvarchar](max) NULL,
	[objectId] [uniqueidentifier] NOT NULL,
	[stockName] [nvarchar](max) NOT NULL,
	[amount] [int] NOT NULL,
	[sale] [int] NOT NULL,
	[createTime] [datetime2](7) NULL,
	[isDeleted] [bit] NOT NULL,
	[allday] [bit] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exhibition]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exhibition](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[imgs] [nvarchar](max) NULL,
	[status] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[createTime] [datetime2](7) NOT NULL,
	[basicPrice] [decimal](18, 2) NOT NULL,
	[passType] [int] NULL,
	[isMultiPart] [bit] NOT NULL,
	[exhibitions] [nvarchar](max) NULL,
	[beforeDays] [int] NOT NULL,
	[forbiddenRule] [varchar](max) NULL,
	[totalAmount] [int] NULL,
 CONSTRAINT [PK_Exhibition] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[trade_no] [bigint] NOT NULL,
	[createTime] [datetime2](7) NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[payedAmount] [decimal](18, 2) NOT NULL,
	[status] [int] NOT NULL,
	[objectId] [nvarchar](48) NOT NULL,
	[userId] [bigint] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[extraInfo] [nvarchar](max) NULL,
	[expireDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[trade_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[createTime] [datetime2](7) NULL,
	[AppointmentId] [nvarchar](48) NOT NULL,
	[TUserId] [bigint] NOT NULL,
	[ticketNumber] [nvarchar](32) NOT NULL,
	[startTime] [datetime2](7) NOT NULL,
	[endTime] [datetime2](7) NOT NULL,
	[stauts] [int] NOT NULL,
	[userID] [bigint] NOT NULL,
	[objectId] [bigint] NOT NULL,
	[ota] [int] NULL,
	[usedCount] [int] NULL,
	[totalCount] [int] NULL,
	[cancelCount] [int] NULL,
	[verifyTime] [datetime] NULL,
	[isMultiPart] [bit] NULL,
	[QRCode] [varchar](128) NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [bigint] NOT NULL,
	[authLevel] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[openId] [varchar](64) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](max) NULL,
	[phoneNumber] [nvarchar](max) NULL,
	[idCard] [nvarchar](max) NULL,
	[createTime] [datetime2](7) NOT NULL,
	[userID] [bigint] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebRouteConfig]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebRouteConfig](
	[id] [int] NULL,
	[keyPath] [varchar](50) NULL,
	[routePath] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WechatBill]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatBill](
	[paymentId] [bigint] NOT NULL,
	[sourceId] [nvarchar](20) NULL,
	[payTitle] [nvarchar](max) NULL,
	[money] [decimal](18, 2) NOT NULL,
	[userId] [bigint] NOT NULL,
	[type] [int] NOT NULL,
	[status] [int] NOT NULL,
	[paymentCode] [nvarchar](50) NULL,
	[ip] [nvarchar](50) NULL,
	[parameters] [nvarchar](200) NULL,
	[payedMsg] [nvarchar](255) NULL,
	[tradeNo] [bigint] NOT NULL,
	[createTime] [datetime2](7) NOT NULL,
	[updateTime] [datetime2](7) NULL,
	[Attach] [varchar](max) NULL,
	[transactionId] [varchar](64) NULL,
 CONSTRAINT [PK_WechatBill_1] PRIMARY KEY CLUSTERED 
(
	[paymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WechatBillRefund]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatBillRefund](
	[refundId] [bigint] NOT NULL,
	[aftersalesId] [nvarchar](20) NULL,
	[money] [decimal](18, 2) NOT NULL,
	[userId] [int] NULL,
	[sourceId] [nvarchar](20) NULL,
	[paymentCode] [nvarchar](50) NULL,
	[tradeNo] [bigint] NOT NULL,
	[status] [int] NOT NULL,
	[memo] [nvarchar](max) NULL,
	[createTime] [datetime2](7) NOT NULL,
	[updateTime] [datetime2](7) NULL,
 CONSTRAINT [PK_WechatBillRefund] PRIMARY KEY CLUSTERED 
(
	[refundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WechatMerchantConfig]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatMerchantConfig](
	[appid] [varchar](64) NOT NULL,
	[mchId] [varchar](64) NOT NULL,
	[apiKey] [varchar](128) NULL,
	[apiv3Key] [varchar](128) NULL,
	[certificate] [varchar](128) NOT NULL,
	[rsaPublicKey] [varchar](128) NULL,
 CONSTRAINT [PK_WechatMerchantConfig] PRIMARY KEY CLUSTERED 
(
	[appid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XieChengConfig]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XieChengConfig](
	[Account] [nvarchar](64) NOT NULL,
	[ApiKey] [nvarchar](64) NULL,
	[AESKey] [nvarchar](64) NULL,
	[AESVector] [nvarchar](64) NULL,
 CONSTRAINT [PK_XieChengConfig] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XieChengOrder]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XieChengOrder](
	[otaOrderId] [nvarchar](128) NOT NULL,
	[trade_no] [bigint] NOT NULL,
	[PLU] [nvarchar](max) NULL,
	[locale] [nvarchar](max) NULL,
	[createTime] [datetime2](7) NULL,
	[useStartDate] [nvarchar](max) NULL,
	[useEndDate] [nvarchar](max) NULL,
	[price] [decimal](18, 2) NULL,
	[quantity] [int] NULL,
	[amount] [decimal](18, 2) NULL,
	[payedAmount] [decimal](18, 2) NULL,
	[status] [int] NULL,
	[objectId] [nvarchar](max) NULL,
	[userId] [bigint] NOT NULL,
	[name] [nvarchar](max) NULL,
	[itemId] [nvarchar](32) NULL,
	[cancelQuantity] [int] NULL,
	[useQuantity] [int] NULL,
	[orderStatus] [int] NULL,
	[passengerIds] [nvarchar](max) NULL,
 CONSTRAINT [PK_XieChengOrder] PRIMARY KEY CLUSTERED 
(
	[otaOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XieChengPassenger]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XieChengPassenger](
	[passengerId] [nvarchar](450) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[mobile] [nvarchar](max) NOT NULL,
	[cardType] [nvarchar](max) NOT NULL,
	[cardNo] [nvarchar](max) NOT NULL,
	[gender] [nvarchar](max) NOT NULL,
	[nationalityName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_XieChengPassenger] PRIMARY KEY CLUSTERED 
(
	[passengerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XieChengTicket]    Script Date: 2024/11/7 17:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XieChengTicket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ticketId] [int] NULL,
	[OTAPassengerId] [nvarchar](64) NULL,
	[itemId] [nvarchar](64) NULL,
	[voucherStatus] [int] NULL,
 CONSTRAINT [PK_XieChengTicket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240120084548_v1.0.0', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123062138_v1.0.0', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123062231_v1.0.1', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123062846_v1.0.2', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123062934_v1.0.3', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123063213_v1.0.4', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123063706_v1.0.5', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123064033_v1.0.6', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123065649_v1.0.7', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123071854_v1.0.8', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123083405_v1.1.0', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240123084856_v1.1.1', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124023733_v1.1.2', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124024511_v1.1.3', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124024947_v1.1.4', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124031123_v1.1.5', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124055225_v1.1.6', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124061532_v1.1.7', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124062356_v1.1.8', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124072341_v1.1.9', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240124073819_v1.2.0', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240126081035_v1.2.1', N'7.0.14')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240329054303_v13.0', N'8.0.1')
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0135209b-209f-4a42-a242-7255b50c10d7', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 0, 0, CAST(N'2024-04-17T16:36:07.8684072' AS DateTime2), 0, 0)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8683862' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0177f684-afcc-4721-95f7-9c7e407a97b1', 46, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8735497' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'022cd8ab-a079-4f65-902a-c67ef0678e37', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8682791' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'02537d9c-2663-4d1f-a17f-03db8f0f9867', 88, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-18T00:00:00.1411116' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'02654bb3-07a6-4a26-9a40-ebeda6891f79', 16, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8701380' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0280698d-143c-4bc6-87d8-06d3768fac69', 18, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8704088' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'028294d8-face-428b-a5bd-5203016d4529', 68, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8761714' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'02cdc4b5-f46c-40d1-99d7-bc8d3aa5412d', 1, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 10000, CAST(N'2024-04-17T16:36:07.8758033' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'030eddd2-6220-4571-bac3-d40e0148157b', 55, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8746285' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'03ad882f-2b87-4cec-abce-0d51f2cbac6a', 82, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8778292' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'044dd807-d289-4dcd-b817-1557db9065f9', 45, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8734359' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'046cd09f-9b81-4285-8a5a-37cde7f4807a', 40, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8729566' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0474cd9a-8a75-465a-9be7-5ec2fd4cfc8c', 73, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8766990' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'05da766e-843e-4596-96d0-f607c3e88b40', 55, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8747128' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'061e3e05-8ae8-4314-845d-f7dd5d51121d', 88, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-18T00:00:00.4469865' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'06e67650-9122-4b58-8242-9ed41a4cc8e3', 67, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8761313' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'08b36bbe-92c1-43c3-a1d0-73545ad5564b', 25, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8712005' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'08df1933-d998-41ab-b78a-cc008fc841cf', 33, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8721934' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'09194aa3-0114-4846-8865-0fe8741bd152', 64, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8757059' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'092861bd-d601-4f7c-9a5a-aef6f1f57f78', 53, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8744723' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'09332874-9b0d-464b-be20-35d701288156', 23, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8709614' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'09ea4a3a-389c-4929-bfda-081b3e57be31', 75, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8770513' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0b3ea54a-cd3b-4fb6-a86b-3612eca48a45', 41, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8731038' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0b672af2-fab6-4ae6-967d-b1df0a91e974', 16, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8701910' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0c8f4d77-3d16-401b-ad8e-51b014127dd2', 45, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8734778' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0cd6f91e-0160-43f6-b687-d61dce7f639a', 35, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8723611' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0db6b3e7-0342-491b-b62f-0dd1eaafc559', 2, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8684696' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0ddc98b6-6791-4bf5-b09c-1d73abc46500', 74, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8769451' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0de6fce1-d3b7-4270-a29e-292dc239640e', 39, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8727534' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0e465b80-d084-48fb-b5ac-3b7019e6010b', 39, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8728145' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0e49018b-143b-46a1-a3ab-6e495251ffb7', 22, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8708583' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0e885e83-be28-4587-88d3-212f6ad4a2d1', 62, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8755617' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0ee1a696-7f2c-44e4-8511-32d2b8804a04', 66, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8759650' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0f25e615-ca13-49c0-a5d5-b161af82d020', 6, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8689753' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0f54a3ef-bda0-4804-8c0e-4607d198f898', 27, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8714757' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'0f6ef6f3-ec2b-41ab-a8f5-805e14af594c', 32, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8720465' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'10fb2c99-766d-4f06-b3fe-85c03a490292', 42, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8731461' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'110df07f-7bf7-4fd6-8ab8-211444be5f57', 71, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8764806' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'129002e0-58c2-4052-95bd-693d1db23065', 42, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8731866' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'12ebbaeb-6243-475b-b017-05fa510509c6', 52, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8743451' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'13ac85f6-df76-40f2-b618-0776965a3b0b', 58, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8750500' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'13fc4b7a-c9c0-4001-9dc1-c63969c2372a', 28, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8715901' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'14515341-8e6c-4b4b-90a2-efb03bfff06a', 35, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8723178' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'14a5e981-944e-4874-a4c4-1dc3e2b7991e', 84, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8779947' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'14bdb656-6488-4914-9388-85e4a2918b27', 32, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8720257' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'15c80f41-cf12-4f01-8a6a-336581e83438', 64, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8757261' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'176e5476-32fd-4b18-8b68-ed54dc5d7e95', 17, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8702826' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'17a5fa49-df0b-40ef-a38a-cd99ac1ff6f4', 29, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8716717' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'17b85590-cc17-42bb-8c73-08ea2440993a', 63, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8755822' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1872c894-ed3e-4ece-90a8-53e32d16ed67', 65, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8759211' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'19551e99-e427-4754-8d6c-dbe862bf6ea6', 12, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8696926' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1a2bb7c9-b949-494b-ac96-42f8f5d2ae19', 30, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8717349' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1a8c2ce8-334c-454b-8a93-177d945e038b', 56, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8748646' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1ab71b2b-0114-4234-9ca3-2c2bd44d9deb', 62, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8754686' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1b25dea9-e9ce-4c76-97ba-9ddcf49259ca', 16, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8702403' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1bbf3799-5da1-431f-925a-e7a14200c6c9', 64, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8757465' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1c8e300c-e752-4d4b-981f-93d928f5f99b', 59, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8751567' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1d1f557a-f20c-4a39-87aa-be94e049722f', 35, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8723405' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1d2427ba-1efb-4f44-b4de-58ca3e85dada', 52, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8743038' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1d5f3c19-a0f3-40b1-b633-18e8d15bd201', 2, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8684284' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1d69e886-9ed0-4819-be68-c67ed63812a4', 36, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8724510' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1e759056-d115-4628-80b2-2fd3da4e2db4', 77, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8772789' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1f929630-2692-4383-8326-c21d746801a6', 50, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8740437' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1fae0e92-4e01-4574-8ae4-6edcfe1be720', 76, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8770923' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'1fbe11e3-2221-491e-a12a-aadce1c4cb60', 61, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8753663' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'20443de7-271b-4a82-9407-92dd5865c88b', 27, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8714961' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'206c5c44-7c33-4a4a-8c16-2d23630b4fa1', 13, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8697769' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'20db5d13-1cc9-4a6e-8a58-5e4c0ab70588', 3, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8686152' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2104e00a-9ea0-48f0-aba2-41df79b0a944', 9, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8693640' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'217bb314-f9ae-4434-af8f-434c26294435', 69, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8763161' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'21b2725f-2715-44a6-b497-bb30cbd93a04', 51, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8741976' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'225c5738-3a4b-423c-b301-2486483807b9', 45, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8735281' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'234be746-8f89-4d06-a1c5-7bf168489419', 71, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8765551' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'23974300-592f-44f2-97bb-86deface4972', 53, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8744923' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'241fbbe6-92d0-4e88-bcf1-98d5288a48d6', 74, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8769216' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2503937c-d017-499e-918f-5e0966060bb1', 42, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8731663' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'259565cf-58df-42c7-9090-b2173e647c83', 56, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8748266' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'28aa3e0b-6b34-494d-a207-f306e200d3ec', 34, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8722969' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2905456b-1ba2-493c-a54e-426e41c6ed3a', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8681957' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'29739985-f6de-497e-ad75-0db7f0446100', 29, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8716512' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'29f22b2f-4318-4b25-bae4-129537da69a9', 47, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8737388' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2a4d2c3f-05a7-4af7-b55d-a56d36d76324', 48, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8738550' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2ac0e435-4591-4a6f-9db7-8821d9f539b2', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8682164' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2ac23893-d8ec-43af-8c34-89e0ea7fe834', 28, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8715469' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2b1a8686-7516-4a97-b551-55e5183f8c55', 21, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8707532' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2bea1b6f-5d60-48bb-af15-cab101db91a0', 85, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8781406' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2c2bccb7-55a2-4b6b-aea2-740438d54426', 27, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8714128' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2e015771-06c4-4b03-ae07-82b905382632', 4, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8687741' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2f35c481-75b0-4dcd-9df6-fc224401bb72', 55, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8746507' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'2ff6d8e1-9003-4c34-aa1e-9d1f6ac8f87c', 77, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8771968' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'30592514-15df-461a-911b-f1de78f8378e', 62, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8755098' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'310ab7d8-d489-4f9e-b281-6208a127d903', 22, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8708171' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'31c9fa74-1717-4fcd-bb8f-e1bae96ebf87', 47, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8737176' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'31f1cb63-5496-4c99-a907-16e1b004c12f', 23, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8710441' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'322333e1-55cd-49a8-b325-f2ed2827f04b', 26, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8713711' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'326cf02e-1f42-4f0f-b147-0c40c17a5d63', 82, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8778708' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3281fa7e-6882-403d-b718-2e4d8c7c2516', 29, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8716921' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'32e37989-7e05-42ed-a598-9609c734a7b7', 26, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8713916' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'32f23648-1457-4268-ae7e-522e014becd0', 81, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8777039' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'331a6972-9265-4b46-bf22-011ff458c6e6', 46, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8736345' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'341cdc83-9226-47b2-9d7a-d0f935f1d3e0', 19, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8705417' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3420d137-644f-46e9-93f2-d6a1e8bd2341', 52, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8743879' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'349b76ab-7fdc-4b31-af1d-eaae966f7d09', 43, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8732279' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'34ccd6f8-6459-48b3-b480-9b25c9fbf25d', 60, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8752620' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'352e3f98-3f56-4c6e-9a20-35cb111e617b', 66, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8760471' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'369b6ca0-52c6-4036-9251-8213f8fea145', 39, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8728649' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'36ffaacf-9e4d-4ac6-a0ae-1074c08b563b', 81, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8776202' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3731b008-d556-4335-98a8-e45ef7e25480', 87, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T17:26:09.5177279' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'374d319f-8cb2-44d0-befd-6d4101b35ba2', 19, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8704937' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'383140dd-f014-4f7f-95ce-65f3da8607ca', 29, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8716311' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'38a850c2-0dcb-48b7-8635-e7da3c4a1cf0', 24, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8711356' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'397eb3d9-35c6-4572-abd0-9f611a57f1db', 35, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8723884' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'39d64323-3f3e-476e-845d-78e4a2cb0955', 12, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8696508' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'39e49b65-688e-4f84-ab98-6ffa236a2d78', 86, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T17:25:40.2367661' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3b7ff9ec-d9e1-41f6-9049-3427a4b94b2c', 6, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8690823' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3c5db8ad-8cde-4036-a54a-b09c0011fb4d', 7, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8691731' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3ca9f018-97dd-4acc-a2ad-a3c8965aa543', 85, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8780983' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3cb3f1b2-f9ed-48b4-8852-aa808670b5d3', 56, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8747749' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3cf45b42-4bb9-4fd9-a3a1-9d7602d9396e', 49, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8739528' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3d86c013-ac33-4cb3-925e-cddc6116902a', 73, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8767189' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3DC16154-C4F5-42D6-BEEC-CC3B09D2D2D6', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:00:00.0000000' AS DateTime2), N'1', N'1', N'd772c8d4-0cc9-40c1-ad8d-8376911dcfca', N'不打烊', 100, 0, CAST(N'2024-09-05T10:05:52.0356727' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3dd1ff3f-4e05-4bbb-a11a-6823a91fc7ce', 37, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8726066' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3df5e7dd-3280-40c5-a0e5-f98760ef5d81', 6, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8690577' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3e150309-2d6b-4827-900a-5c8b98a336a7', 18, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8704293' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3ed9e46f-fe01-4008-87e1-7d08f90163af', 72, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8766588' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3f0c2569-2de1-48b9-bb11-96bfadb26d82', 56, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8747546' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3f0ff11f-4414-479f-9166-179d50157cf3', 49, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8739969' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3f629162-f0cd-4bc2-9a1d-6152c5e239e3', 78, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8773406' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'3ff88816-7eee-4b1a-82dc-8a815e0574b6', 20, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8706270' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4037adc4-6cf2-4a72-89d3-5befe46fac16', 85, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8781810' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4073ee4a-9c91-4942-8eac-2cb6c983ed41', 30, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8717760' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'40d3236a-ac80-4826-8801-3217d106d4a0', 70, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8764192' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'414f997a-9388-40b6-bff6-7d5f82d57e2c', 61, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8754285' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'41a6b228-8f66-4d69-9bcf-71ab50afa80c', 75, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8770082' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4255c426-8b1f-4fbf-8e1d-c7d15539ec87', 79, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8774031' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'42801a6f-aa0c-4db8-9159-8c44f8dad735', 1, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8683211' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'42cce3d8-da80-4cb6-bcbc-8d657799edf8', 65, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8759424' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'42e2a900-9042-4f18-b99b-7d60fc8b5d94', 15, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8701165' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'43490de6-8e58-4e56-8e1e-e7adf7a4197c', 68, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8761932' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'43751819-6b3d-49c5-954a-663b3b88587d', 24, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8711771' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'439ac02b-ab28-42f2-80b1-2aa2baef9ebf', 54, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8746079' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'43d40e76-d8fd-4ccf-a443-7f555d952401', 67, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8760901' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'44456652-3567-4677-a64e-37589cc319a9', 61, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8754487' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'44b1f93e-abab-40a3-862b-982319dfe879', 50, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8741753' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'46dfd767-8e8a-4bbe-996c-03362ebe2172', 79, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8774634' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'478087ee-eb09-4857-ad88-5aaccdfc30b2', 86, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T17:25:40.7041528' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'48422a8e-dd63-429c-9148-f119c603ada0', 54, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8745673' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'48eb0aef-cf75-4e5c-bc6c-2922b22165d6', 48, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8737793' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4a7b59de-9706-4684-a22d-4689cea8f0d9', 25, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8712448' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4ada76a9-1869-4e30-bac2-7dc36f2e82ac', 30, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8718190' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4b3cc359-edd5-4840-8fd7-5188e4b284fa', 82, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8778503' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4b77984a-d71d-4aaa-b850-2a629ae4802e', 13, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8698180' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4bc3b8a2-6aa9-47d5-9dc2-de5770825e12', 84, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8780778' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4c38ffb3-fc33-4002-88a2-9bde3ce68baf', 44, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8733522' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4c7db1c2-e5ce-4191-bb2e-4ab7c5c5b855', 17, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8702616' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4da1af4f-3b4c-4575-a784-791c9cd0c630', 5, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8688187' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4dae9f82-299b-4a26-b4e5-669e80fd8611', 40, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8729064' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4e0d8071-f634-4ad7-82f8-b0dd33cf2e67', 59, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8752417' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4eca74b2-e8bb-4e54-bd72-046d29aac346', 84, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8780364' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4ee69057-8dc5-49e2-a942-40c48cf1950d', 63, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8756653' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4f0bda07-6261-4f45-a354-0d234d7a9bb8', 11, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8695868' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4f265d10-4ed2-4846-83b5-87cacf0b2b2c', 28, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8715164' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'4f3c1d08-9641-4e60-9bc5-a6932a6a9506', 52, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8743673' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'51f8c9f0-a87c-4b69-afcd-7519c1d9aadb', 46, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8735913' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'52bfa0cd-0aa9-4cac-a3a1-404685e65c06', 70, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8763764' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'53433e55-01fe-48f6-b363-650008b353c6', 60, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8752823' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'535ec9a4-5a72-4cce-8a2a-7e8b7319da5c', 47, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8736750' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'53a18890-eda3-4962-ab68-7a609f397fb4', 59, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8751985' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5435791a-0027-4234-ac63-ef093cb217d1', 2, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8685412' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'54854c39-6848-4943-9cb2-c5cab495113b', 15, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8700615' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'590d2dca-e37b-4362-a1cc-50c7fc498afb', 20, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8706068' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'59dabbd9-a027-47c5-a2cd-eb23f84a6523', 76, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8771545' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5a47c688-91d4-4908-8c9b-3cb23b7afad0', 77, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8772370' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5a850357-1738-4d0e-a437-bee01f6ecb51', 58, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8750715' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5aa5d8cc-ac3f-459a-b79e-4fbdd8a7367c', 11, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8695658' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5b97cbdc-d908-406c-9ea0-82b121272ecd', 57, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8750066' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5c0640e3-ae86-48da-981f-c9ee16d6a8e0', 61, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8753868' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5cd1c789-4d0a-4735-93c5-6428e0989b67', 84, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8780163' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5ce41a5f-7968-4a1b-bace-97ceff49c76b', 47, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8736548' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5d29139a-2d77-47a8-9881-3dfcc094e046', 34, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8722560' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5d629498-df4b-4b9c-af34-647794ed2e6b', 20, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8705861' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5dc97f45-b34f-4f39-997a-4f88aefaebba', 51, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8742606' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5e6ed89a-4f3c-46e6-8653-8b8b86fe3a6e', 15, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8700407' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5ed6f27d-4848-409e-99a6-f8655e35f7aa', 80, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8775066' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5eea6346-e39f-4e70-90e0-4c615f2e0ec6', 14, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8699986' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5f01a514-e560-4d12-9e9d-384a4fa65d30', 53, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8744314' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5f0254db-d8e2-444d-a66a-5de591317f20', 30, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8717558' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5fa1fa7f-4525-4560-a49f-e5744a9c87b3', 72, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8765967' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'5fcbc414-30b7-464b-bff0-3cccdeff31d9', 21, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8707738' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'603f06ca-b5bc-424f-a9cf-af5e202132e7', 14, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8698639' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6208aa35-c5cb-4f71-a89d-0d4a6a7d9a6c', 72, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8766169' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6296f80e-d19d-441b-999d-f21fd81ef1ae', 78, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8773808' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6367e2ad-d19d-4388-b44d-034aa15bf35f', 89, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-09-05T10:05:50.9796943' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'638685e2-3b97-4e11-9810-53c0d85c1bdc', 1, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8683631' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'648747cb-03f4-4b28-86b9-4e86a6eef96d', 41, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8730411' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6520d205-1fba-46e4-8d34-cbef0c297d67', 55, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8746918' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6674b25f-f313-4acd-ab8b-5bff2eee4e05', 70, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8764393' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'682a32c7-5019-4d21-b841-f9006a9310f9', 45, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8734982' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'69a7abf3-312e-486b-bc50-6d198b1e9010', 39, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8727940' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6a6ccfce-2da7-4775-89f0-d55de2833141', 12, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8696716' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6aa5c2fb-6bb6-430b-a19f-c1ce1e0a24e2', 81, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8776613' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6acb5e54-7406-467a-a640-602867f152e3', 37, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8726269' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6b0c7971-3427-4b12-9449-61dcc2c5eca4', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8683001' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6b3af372-2c95-4cfb-b14b-be00652e72df', 26, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8713484' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6b5d2c00-366c-4d60-ac83-dccf6e3b4a2d', 69, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8763563' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6bce38b1-9b8f-4a8b-9190-472ae6803142', 72, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8766385' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6c13d3f5-bf6b-4aab-9536-64b31a1558c3', 89, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-09-05T10:05:53.2468585' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6cba044d-5e54-46ff-b3b8-b53c7c621619', 79, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8774843' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6d9a3fc3-4a6b-4a77-95a2-da7ad99488ed', 32, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8720882' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6ee057b9-1ca9-4c9f-a5e0-6e0e2ee6d880', 33, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8721313' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6ef99296-934c-4219-b03b-341640637318', 72, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8766785' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'6feda9f0-1ba5-4eea-8f8a-20b7d9af52ad', 33, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8721526' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7003139c-5023-4283-9cf9-cd6ca8ffcbc6', 87, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T17:26:04.1713616' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'70e11b12-4c28-45b0-82b0-104194a78643', 74, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8769663' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'71c36dac-73b5-4fe3-a702-ec88723a5382', 10, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8695142' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7216e35c-1c92-41d7-aa4b-c39a4552b047', 78, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8772993' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'73445952-af3a-4131-a233-72fdcf9ae14f', 77, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8772569' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'741759e6-5bb0-49e1-a3cc-bb113ca0ae47', 78, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8773607' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'742156bf-6a9f-4662-857e-97deabe200ea', 31, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8719574' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'74bbda43-54ea-4bed-9f93-151efa521645', 44, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8733320' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'74f82661-adcc-4339-ac94-74e2fab4c409', 84, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8780575' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7500682e-c318-4afc-bacd-dcb41557ccff', 76, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8771126' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7511606b-7185-4c35-ad88-d42365134d48', 32, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8720043' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'75414cb7-77d5-4e5f-93cb-04c14abca85e', 38, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8726699' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'75dc0700-01bd-4136-b59a-d446386ed6c9', 75, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8770719' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'75de1689-501b-4cb9-b8e1-f23f7eb5fa4e', 26, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8713069' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'76d84134-a70f-462f-94af-c02516c40d88', 53, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8744518' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'77abbbc8-dea1-477d-80b7-dd434605d998', 4, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8687532' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'77abbcc4-0222-45a4-83fc-3198202ee695', 58, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8751156' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7854de76-87ae-41bb-9d42-e5862b73f3ae', 21, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8707121' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7888723b-32fa-470b-9fd3-907a20528966', 43, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8732487' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'78cbaeb9-a1b7-4cb0-8cfa-331bea3aaa66', 31, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8718912' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'78cc764d-2b0d-41b9-81ec-37b4e28de5d9', 76, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8771330' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'78ea4f81-376a-4e29-bff7-5753cf6c411d', 85, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8781202' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'79f319e6-d84d-4d98-9c86-054f5320066c', 73, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8768060' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7a70de26-96ce-4bd9-955b-fbd9db920a97', 80, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8775369' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7aa16179-8925-4808-926d-88c13a795e23', 65, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8758415' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7c326dc1-7360-4abb-8019-415e22c9acee', 35, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8724108' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7d8b066b-6e38-4421-b255-21a851003b2b', 68, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8762133' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7db106f7-2246-4884-9ca5-ff396744a20d', 27, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8714539' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7e79cd6a-8468-4c92-bc8b-bc3813d92b7d', 12, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8697137' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'7ed67f6e-955f-4c9a-bead-ffb89ca675f9', 88, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-18T00:00:01.1591748' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'80885172-7326-43d1-b35a-50fcc68eea6e', 79, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8774434' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'80a62e85-1aae-4408-8641-591ea3b276bf', 36, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8725145' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'81393c0a-9172-40e6-a581-e9cdd923c0ea', 18, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8703680' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'81cd3ae1-2904-41eb-a3d8-e4077f00da98', 44, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8733746' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'833f3a98-ca4c-405d-b1d3-1c1463ceecd1', 14, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8699747' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'83603f3c-c5b7-4707-95e1-099b4f90448d', 37, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8725657' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'83ba1b4d-954e-42e8-b0e4-7f0d65962c09', 67, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8761107' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'851071f6-b35b-41b8-bfb6-8a1091adc932', 8, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8692806' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'853749a4-19af-47aa-a5aa-4d489c816cea', 2, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8684915' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'86092e6e-1ff3-4296-8e6d-07699577148f', 43, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8733117' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'86498f9c-66f2-4a9f-a15e-f1250a541c93', 75, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8770288' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8672e7d0-850b-4f15-8eaa-adab8fac31a8', 40, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8729775' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8687b1c4-2e53-4f1d-8071-b86fd16479d6', 71, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8765762' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'875d4e76-070f-4a8b-ac4e-c877357a0eb2', 37, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8725448' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'875dd56b-b930-4551-adb4-f680f674fdcf', 66, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8760265' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'877adced-746e-4363-a89f-5ef0fca12189', 24, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8710914' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'87cb9f9c-992b-4e4a-98f3-f99c3126f63d', 5, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8687974' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'87e3dfa9-edb2-42b1-98b4-50272be1702d', 14, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8698854' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'88303153-b1e3-4aa8-8169-db24952b39ab', 69, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8762746' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'88a75f6b-28db-4dae-a05f-6fa706847f30', 8, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8692370' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'890e3466-caed-415c-b1a4-78c4b578a316', 6, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8689070' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'89af93b2-a6df-4a65-a903-5a0c3f7f5223', 65, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8758735' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'89bc7faa-0a40-4066-b851-1d8555607f7d', 21, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8707328' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'89e95cf3-ca33-4b2c-9a5e-a7082dc135fb', 51, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8742189' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8a6da32e-1617-4f66-8598-d12da26c4b66', 38, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8726491' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8a6f606f-994a-43e0-9266-656b48e1ecdb', 17, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8703041' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8ae11c5a-2ba7-480a-b680-b12515d54aae', 73, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8768405' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8b0072ab-7d48-4a6b-b442-7c48226c27b1', 82, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8777603' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8b141777-ec22-4603-a211-a4acdff7d501', 79, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8774231' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8b27e397-dcbf-48d2-9a2c-6645f9a02ad5', 3, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8686637' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8cad9816-e940-43c4-80be-987d8d6a663a', 44, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8734158' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8cd2683c-568b-4349-8a1e-ea5bc605fa5b', 14, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8699381' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8f5db095-d772-491e-b19d-463384f385d6', 21, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8706898' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8f949e4d-7f83-41a8-87bd-1ae270f2edfd', 28, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8716110' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'8f968490-b7ea-45f6-9bfc-2eb1cac93959', 83, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8779341' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'90334937-4b46-4683-97ca-ca5933e8efe7', 4, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8686878' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9073858a-2535-4ca4-b20e-aff6c2e04621', 54, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8745878' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'913ee0b5-50b0-4476-846e-470efbd2143a', 68, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8762340' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9225a9f4-52e7-4a66-b96f-0ea312928dbb', 48, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8737995' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'927ab216-8cf9-4170-956b-ed67967d2e56', 80, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8775578' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'93a8a8f0-75fe-444b-9302-adc5d158a11c', 83, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8779747' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9488656e-6c47-4f07-ab93-4d942e52edef', 24, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8711564' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'94fc6d66-4e11-4a5b-8951-85dc17888c1c', 24, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8711121' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'956e288f-f4db-4cd4-8833-5273f890a20c', 64, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8756857' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'96bc8403-11f1-4a67-bfba-dcf875dee823', 19, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8705628' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'997bc500-d016-4f2d-8ad3-436d011eee5b', 10, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8694284' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9982f2e1-992b-44b4-a787-7cb0fdf89978', 9, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8693867' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'99e85813-36f5-4a40-8bbd-f8ac5cd731c8', 40, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8729351' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9a72aa7c-417d-4316-909f-c72f61a03bd7', 3, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8686398' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9b230b00-0a13-43b8-bae9-8430041e3b4b', 56, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8747332' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9bb4446b-d0bb-483e-a768-6ccface3829c', 9, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8693219' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9bfcfd01-c48c-41ac-bf43-25ea7ec113a1', 66, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8759856' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9c629649-105d-406e-a323-504d73d2418e', 54, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8745125' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9c8426cb-9a53-4020-a81c-8155c4461fd5', 60, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8753024' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9d2b4996-9abc-4af4-ad81-51b8dddb6d93', 86, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T17:25:41.3774512' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9d64bbaa-accc-45d5-b6e6-ee250c824eab', 50, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8740176' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9dea6abf-3bf7-4b0e-984d-c0967236aa34', 9, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8694076' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9df514d4-7e1b-444c-a6ed-32443df555e0', 28, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8715673' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9f68c982-b137-43d4-abd1-66e1cde30a6a', 43, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8732915' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'9facb0c7-c2c7-44cc-aa23-cdf53cf41b80', 22, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8707940' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a1c4abc2-9cc7-48c0-9e43-c2df6d156bc3', 8, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8693014' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a364a40d-12ec-4a42-a47d-5bc9c0664887', 11, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8696078' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a36ffd17-abcc-4fc2-be05-4e8b7480c594', 48, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8738884' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a6958176-664e-43df-94f3-1ff58842b8fd', 38, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8726901' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a6a351c7-18d3-4b4a-9760-24b18dd1d26f', 4, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8687319' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a6e27f45-d024-4e5d-8a07-85bb41ec3bca', 20, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8706482' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a70dfe17-298a-4279-a8fa-5a176f8826b0', 59, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8752213' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a8514541-0165-4f75-a48c-23fa0daa6dcc', 80, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8775782' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a893a23a-ad0f-4816-b463-3b96c0557c23', 38, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8727106' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a909ceda-34e6-4e70-a6c0-b3597d9f082d', 13, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8697978' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a92c1b96-3986-40a5-8d0a-d58a69aa95a5', 44, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8733956' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a939f5c4-9961-4354-8686-d7f6ef055063', 87, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T17:26:04.7365989' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a9cce356-68cf-4b9d-8562-2cd9be7be9ad', 86, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T17:25:39.3005311' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'a9ed2132-1075-4a7a-81fb-49e7c51774da', 34, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8722359' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ac5d05e4-4aff-41c3-bfad-3d06c83fd10c', 32, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8720672' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'acf635ec-9b4a-4f48-8ed4-1ddcaecd495d', 23, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8709991' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'add5b9de-d9a5-429f-95ed-84e04e9064b8', 67, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8760692' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'af486323-2371-4341-880d-6e607aa7e636', 10, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8694701' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'afa16fd4-a4e7-425a-aa14-1268370f2275', 69, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8762958' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b020402c-131a-422e-b73b-bee622144208', 23, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8710222' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b0bee7c3-1e49-4d9d-a456-3a55854052a4', 31, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8719264' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b11c9b95-2945-434e-affe-8e2934a2cfa9', 89, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-09-05T10:05:49.7013476' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b23492c3-f61a-43cb-a7eb-ef5f907553c5', 12, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8697362' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b3aedbe3-a964-4baf-a459-be47e7d93899', 11, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8695443' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b43f51ec-9197-43ef-a26a-d32aa2d69ea9', 39, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8727737' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b46427c5-3510-47ba-8b00-319b3d9101e1', 36, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8724925' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b7b9093d-091c-4b68-8934-a3a3798fda49', 54, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8745463' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'b99293e2-ff57-4932-a0df-c2da85891ac4', 17, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8703244' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'BA050247-0548-4A05-9C60-1D8D6672A05B', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:00:00.0000000' AS DateTime2), N'1', N'1', N'33d09127-6044-4b40-a394-9968d7e132c4', N'不打烊', 100, 0, CAST(N'2024-09-05T10:05:52.0702622' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bacfbf65-7d4c-416f-bfbe-7e443fe17037', 57, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8748974' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bbe68992-902f-405c-a7dc-ee98f4fa4d42', 57, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8750285' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bd22a39e-dc73-4f01-8f75-212a744815a1', 46, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8736141' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bd329571-3899-4e21-96d8-305491919d05', 87, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T17:26:03.5908079' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bd8defb4-c677-4e7a-9993-d58d07f9f53f', 30, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8717962' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bdfc628c-f1df-4218-a2a0-542021d481db', 11, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8696304' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'be4a6c58-f023-4e04-bf99-8640f6aa65b8', 23, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8710701' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'be54c3b7-74c5-43a1-8a77-4caf69e2194c', 36, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8724308' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'beb35381-6daa-4bd8-90ef-0b1a2f29b997', 69, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8763359' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'bef1f627-8e36-4af6-bebb-359823d1b66f', 76, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8771765' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c181d24b-e4e9-4572-8da4-223f2f594b53', 41, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8730833' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c18ce0f9-e105-4fec-99f6-6409f3fb1821', 25, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8712655' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c3a77a96-4a0c-45d3-a410-127cabe59726', 71, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8765333' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c4d40860-bf9b-427f-80ae-44314cbe3945', 41, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8730189' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c4e3d2df-7d01-4e1f-b162-316e6655096b', 49, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8739107' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c5e73968-d798-4193-bb6c-e5c2b89dab4c', 63, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8756230' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c5f9ccc4-ab95-4983-8aac-083ac921ea35', 49, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8739744' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 87, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T17:26:03.2917405' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c6ef0d10-7527-4b61-80c3-458f20721265', 1, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8683418' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c7184689-58c8-4f8e-8963-3bba78988583', 34, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8722155' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c7a1e8b7-f52a-43ae-8d74-2a9ecf21def2', 38, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8727314' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'c7da4c6d-afdd-4133-90ad-d8bb27047451', 61, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8754070' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ca587545-8d4e-4518-9b68-e0efaa52dd77', 7, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8691513' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cac1fb22-1227-445d-b15d-37408b6f3223', 16, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8702168' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cbd3f40c-74b9-4eee-bfe4-bd1b4237c91d', 19, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8705139' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cbe97513-80a1-4690-83c7-d0c73bdb6cf4', 70, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8763988' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ccedca77-8ff6-4bc5-9f11-69adb6e49712', 6, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8690217' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ce26b843-e82a-4b7b-b7d7-170c9d31e85d', 74, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8769002' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ce50e574-8320-464a-9dc5-076f4ec85a13', 29, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8717146' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ce5a3403-9054-4053-af0a-f6f9b4ef8fe2', 5, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8688616' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cec20efa-1073-4251-b5d9-dbdbe6ed1147', 68, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8762543' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cf050abe-d3e0-4651-b370-0db953b98c51', 33, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8721105' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cf19654a-864e-422c-a9e6-d88d6b614281', 15, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8700194' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'cff63600-2173-4a48-b5da-9d1f07461a67', 13, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8698384' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd021e290-67c8-4613-98d1-a575503bfd91', 66, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8760062' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 3, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 49, CAST(N'2024-04-17T16:36:07.8685929' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd36c8396-1b02-4489-8df0-433cf4d36fa7', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8682547' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd440db96-a61b-47be-815e-767d3b27c497', 7, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8691046' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd465fa43-6d42-42e2-b2f6-7d0443082d4e', 43, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8732710' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd5105668-96a3-47d2-8ff5-7e82dc512e89', 50, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8741521' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd6c9f87e-667a-4261-87f8-14f236760cd6', 55, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8746712' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd79b3046-540e-4607-af8b-d222a4b4d96c', 18, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8703885' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 9, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 34, CAST(N'2024-04-17T16:36:07.8693428' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'd94022e3-963a-4ced-b817-9e3b51849b73', 25, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8712860' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'dc253f31-3570-4241-8cd4-ae3ec705c2e1', 82, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8777898' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'DD050247-0548-4A05-9C60-1D8D6672A05B', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), N'1', N'1', N'fffb3cdf-bf8a-4963-bffe-fb2300e929fa', N'不打烊', 100, 0, CAST(N'2024-09-05T10:05:55.6104109' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'deb3e169-f99c-4f4a-bbd0-4cfb789eb699', 89, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-09-05T10:05:54.4705604' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'decb445c-6d58-4839-84ac-4dbb72cbd915', 83, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8779140' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'df9927d8-1d9e-4599-9e42-231b85a3f426', 60, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8753254' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'df997d72-026e-4815-b119-8162378b3e10', 42, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8731238' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'dfc7955a-7a76-4b51-b562-c58dc3607295', 33, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8721729' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e1045f6d-ba58-4b47-be89-e8f4b58f362c', 47, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8736950' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e1400a93-da4f-47d6-9658-9766fe018ea0', 65, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8758993' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e153198a-c784-4c99-88f5-5cf4bfd34a4d', 75, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8769876' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e1efdc6c-3f7d-432f-9d62-18fac7e95c49', 57, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8749204' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e2232601-a78f-4ac2-85a1-0fee6bfab64f', 46, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8735708' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e2340e98-850b-4333-aabd-3df8744f85f6', 19, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8704729' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e25e4cae-bceb-4903-89f6-e7e33f667213', 67, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8761513' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e2d2546c-ebf1-4c26-84c1-1e49661bf9fe', 70, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8764596' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e3d89f0b-e3ca-40b6-bee4-d8b31a10bae0', 49, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8739319' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e4c406d6-0d06-4b02-be27-1f35c76dba61', 3, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8685653' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e50d905a-e118-45ac-85ad-bb87320dc89d', 85, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8781605' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e545ee66-a13c-42f5-9ef6-04c59c70b708', 62, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8755386' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e5df407c-8c00-4049-8761-a47f358fed7a', 40, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8729982' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e611fdb8-e97a-46df-9489-27248564735f', 81, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8776405' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e66c5c27-d80c-4fea-b762-14fc5a95d880', 10, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8694490' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e6bfb2b0-3609-495d-a395-6c4c6b525615', 80, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8775986' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e774f14e-26a5-4885-9998-98488ac31e5f', 51, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8742812' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e7926343-7a2b-4eda-a320-91dacafbbc31', 52, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8743246' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e7d104bf-0379-43e3-b83d-aa1d6b2cf460', 81, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8776816' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e8086776-cb5e-4fe3-99e8-359bc43790af', 42, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8732071' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e813f453-817c-4508-b6bc-9af67fcc3d48', 57, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8749737' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e836160c-56fa-4dd3-87e3-0d45e1d51ff6', 7, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8691952' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e83804c3-9ee4-4add-ae03-0320b2358e57', 86, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T17:25:39.6561769' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e940d7b4-658a-4d59-90e5-6264cdc980c5', 8, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8692162' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e9427cc2-36c5-4cb1-9bb7-138a61c7baf7', 58, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8751356' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e9be25c2-1807-4bf8-a895-97c9f7c913f4', 83, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8778936' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'e9f6eeb2-2a4d-443c-8d4b-88cf3260bf3e', 88, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-18T00:00:00.8018068' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ea040d5d-dc69-499e-93b9-c975c033ae9e', 62, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8754896' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'eb48ccda-7670-4bb5-87d4-95cc34e61674', 22, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8709161' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ec026f37-5b8f-48c9-a9a5-0c1f06add24f', 36, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8724714' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ec3d8b13-8acf-4023-9d9f-ff6f29a0651b', 78, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8773203' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ecbd59b9-651d-49b5-993f-28722b2bfb29', 31, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8718392' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'EE4b3cdf-bf8a-4963-bffe-fb2300e929fa', 0, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), N'1', N'1', N'874b3cdf-bf8a-4963-bffe-fb2300e929fa', N'不打烊', 100, 0, CAST(N'2024-09-05T10:05:54.4506319' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ef15ddbb-9947-4266-bdb8-21c982e531e3', 27, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8714333' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ef80cf25-4df2-4101-9405-cd088523d51d', 45, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8734560' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ef9f0b81-220d-4c75-a838-8f19b4877502', 51, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8742396' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'efcc6e49-4b39-4e1a-955d-bddd7a73d7ab', 10, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8694918' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f04e3970-1b6d-4ca9-8551-81ec67e045f7', 18, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8704498' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f063cbfe-5098-4fd8-ae66-6e49949d3ddc', 74, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8768745' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f22a65b1-805f-4fbb-a148-32cea3d7633a', 13, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8697564' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f243c90f-d039-4fcb-91f0-46eb6b6a4f4b', 22, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8708380' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f2a8db90-dd36-4d48-ba28-512bb179f8b2', 60, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8753459' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f2c2f384-64aa-4ee4-8ff2-78abe45fff51', 2, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8684490' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f2ef21b5-637b-43e3-a020-fa0aa81e26d1', 25, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8712212' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f345c942-cfec-439d-be9c-460e7b0497da', 4, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8687108' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f3b36977-2a3d-4e22-b8c6-95e507eeb29f', 7, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8691266' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f467f43e-08ed-44ff-b1bc-6fc87dcd3eab', 26, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8713278' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f480c887-39c9-4a38-bade-9f9b08f13827', 5, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8688817' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f4e80381-5a54-4ddc-bccf-f8657a6758f3', 73, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8767670' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f504f9c8-64d6-4e3e-ae6a-e983b7723165', 63, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8756027' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f5094d79-1644-4d5b-b7c3-25422a822e87', 48, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8737590' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f6beb942-17b7-4141-b03e-6d1b6bae0afc', 59, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8751774' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f6d43619-bca4-4cf4-9656-56e543a0c95a', 16, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8701619' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f6e28f96-04c0-4635-8043-700a617f5569', 5, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8688411' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f77658ea-d5ba-48b2-be84-9d0ddd8201c4', 58, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8750944' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f7dff1db-7a66-4078-a083-7ed850100f26', 17, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8703471' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f7fe9ff1-842d-4830-9316-d8cf691b4dde', 83, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8779541' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f84505df-1220-4e54-b901-59aa11472b2f', 53, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-17T16:36:07.8744109' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f8dc25d6-f723-4907-b26b-463e076cba90', 41, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8730627' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f9618754-d5cb-4420-a538-d4dd81797878', 15, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8700900' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f97e6b20-6755-4a95-9dd5-61dc1a851fcf', 50, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8741291' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'f9da271e-adda-48aa-93e2-b6de9ddcd902', 88, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', 10000, 0, CAST(N'2024-04-18T00:00:01.5200432' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'fc526a63-5fbf-49de-828b-fdc7b65e8df8', 63, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8756432' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'fcdd40c7-8fb3-46d7-9b58-a4d4458ebbca', 8, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8692580' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'fdac4a28-1eb0-49d3-b0c3-0f7ad5ca3aa5', 20, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8706691' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'fdad0166-15a7-4d18-9fcc-b20fe0913474', 31, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', 10000, 0, CAST(N'2024-04-17T16:36:07.8719805' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'fdc9c359-6005-43d4-8bd4-5db036f24ca6', 34, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-04-17T16:36:07.8722765' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ff41936b-bcc6-44f4-8399-d141aef9d850', 37, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', 10000, 0, CAST(N'2024-04-17T16:36:07.8725862' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ff5aba8c-4ad6-4d98-8a02-28c92aee1f40', 71, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8765007' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ff675c76-01d8-4448-b7a4-eadf6beb762a', 89, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', 10000, 0, CAST(N'2024-09-05T10:05:52.1575773' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Appointment] ([id], [day], [startTime], [endTime], [description], [brief], [objectId], [stockName], [amount], [sale], [createTime], [isDeleted], [allday]) VALUES (N'ff7f8509-7587-4859-9e82-0e25e3043dbb', 77, CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1999-01-01T23:59:59.0000000' AS DateTime2), NULL, NULL, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', 10000, 0, CAST(N'2024-04-17T16:36:07.8772169' AS DateTime2), 0, 1)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'af5588be-c4ce-426b-bd99-0475a166f62d', N'展馆27', N'<p>测试<img src="/uploads/4d62a4e0f6864ed88e63d9b090cf3128.png" alt="" data-href="" style=""/>123</p>', NULL, 0, 0, CAST(N'2024-01-23T14:56:48.5729274' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 0, 1, N'05404c19-8e46-4b19-b896-1d96b3a88421,a89f6614-4b24-47a4-a507-1e89c55bc3ce,500ef993-829c-4a41-9aa2-75057784a1e5', 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'cdc39057-f205-4616-604f-08dcfef5787d', N'测试123', NULL, N'/dingpiao/uploads/752167a6c7064411b22f00673e79de1c.jpg', 0, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'c972d61b-9ba1-4b4f-6050-08dcfef5787d', N'测试1', NULL, N'/dingpiao/uploads/fed37e9ca42547ec85a2ac363e59e398.png', 0, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'b9c13f32-564d-4210-8d1b-14478c78a365', N'展馆12', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729222' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'4fe2ba53-7f55-4ab9-9444-1b6c12f4d954', N'展馆24', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729271' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'05404c19-8e46-4b19-b896-1d96b3a88421', N'展馆3', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729207' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'a89f6614-4b24-47a4-a507-1e89c55bc3ce', N'展馆18', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729231' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'ef0c1c37-2da2-4644-a684-269e244aef9f', N'展馆5', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729211' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'de2b039b-3716-4c5c-9b4e-27fc843a1938', N'展馆28', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729275' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'string', N'string', N'string', 0, 1, CAST(N'2024-11-04T09:09:57.1680000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, 1, N'string', 0, N'string', 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'737716ee-d000-472b-bdb7-2e9fc29f19a2', N'展馆14', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729224' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'53ba1115-40c7-4323-9f36-37265ca6b9bc', N'展馆8', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729217' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'bca2aedd-8a27-4cb3-a5d7-4107d1a30fd4', N'展馆26', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729273' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'd139f7fc-4c31-416b-a7a0-4b74fa833048', N'展馆11', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729221' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'安丰盐课司', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'd5ca8766-10c5-42d4-a924-706f4dc6b593', N'展馆21', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729266' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'100ef993-829c-4a41-9aa2-75057784a1e5', N'展馆25', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729272' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'500ef993-829c-4a41-9aa2-75057784a1e5', N'吴氏家祠', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'd1e53726-d01a-4bea-827a-79ead0780087', N'展馆13', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729223' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'd772c8d4-0cc9-40c1-ad8d-8376911dcfca', N'展馆1', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729204' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 0, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'46cf3f5d-9037-49fb-8c3c-8a9c06076d05', N'展馆20', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729233' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'b8f5edc6-2c74-4590-9a84-958cc3e29de5', N'展馆19', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729232' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'33d09127-6044-4b40-a394-9968d7e132c4', N'展馆0', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729189' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'0057133f-c267-4ff9-bab2-9a7abe240fea', N'展馆7', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729213' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'54b6d460-9169-4729-9d66-9b0e3899cc82', N'展馆17', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729230' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'ad42985a-ec3f-4b64-a180-b613cf03bc87', N'展馆29', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729276' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'b60eacd1-6502-4a5f-b8ab-bc772bb157c5', N'展馆15', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729225' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'774643d8-ad21-4edc-b5fe-cb598558be54', N'展馆10', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729220' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'45687701-d996-44b6-9df6-d5cfe4d7a729', N'展馆9', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729218' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'd49baf0e-f684-4e54-89ac-d73c2126c40b', N'展馆4', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729208' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'754b2502-db47-49dd-b108-da96e49cad14', N'展馆6', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729212' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'403afb6c-9dda-492f-87f0-de11cb730bdc', N'鲍氏大楼', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'c03afb6c-9dda-492f-87f0-de11cb730bdc', N'展馆2', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729206' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'2ea9e21f-0684-43e7-9630-debf6b7382f9', N'展馆16', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729228' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'9ea9e21f-0684-43e7-9630-debf6b7382f9', N'戈湘岚故居', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'eb9f704d-4c32-461d-9a59-f74017bbc2a6', N'展馆22', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729267' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'874b3cdf-bf8a-4963-bffe-fb2300e929fa', N'展馆23', NULL, NULL, 1, 0, CAST(N'2024-01-23T14:56:48.5729268' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 0, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'eeeb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰联票', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(40.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount]) VALUES (N'fffb3cdf-bf8a-4963-bffe-fb2300e929fa', N'安丰携程门票', NULL, NULL, 1, 0, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), 1, 0, NULL, 0, NULL, 1000)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019420001, CAST(N'2024-09-28T16:32:22.0989617' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019540001, CAST(N'2024-08-28T16:32:34.0103955' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019550002, CAST(N'2024-08-28T16:32:35.2163781' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019550003, CAST(N'2024-08-28T16:32:35.9010524' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019560004, CAST(N'2024-08-28T16:32:36.4926446' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019560005, CAST(N'2024-08-28T16:32:36.7798151' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019580006, CAST(N'2024-08-28T16:32:38.5081834' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019590007, CAST(N'2024-08-28T16:32:39.1167088' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019590008, CAST(N'2024-08-28T16:32:39.7403359' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019600009, CAST(N'2024-08-28T16:32:40.3881625' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019600010, CAST(N'2024-08-28T16:32:40.9274807' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019610011, CAST(N'2024-08-28T16:32:41.4745153' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019610012, CAST(N'2024-08-28T16:32:41.9732428' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019620013, CAST(N'2024-08-28T16:32:42.6192108' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019690014, CAST(N'2024-08-28T16:32:49.6887008' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019700015, CAST(N'2024-08-28T16:32:50.4410231' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019700016, CAST(N'2024-08-28T16:32:50.9895355' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019710017, CAST(N'2024-08-28T16:32:51.4949663' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019710018, CAST(N'2024-08-28T16:32:51.9581178' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019720019, CAST(N'2024-08-28T16:32:52.3662160' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019720020, CAST(N'2024-08-28T16:32:52.7797632' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019730021, CAST(N'2024-08-28T16:32:53.2468312' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019730022, CAST(N'2024-08-28T16:32:53.6754063' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019740023, CAST(N'2024-08-28T16:32:54.0445190' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019740024, CAST(N'2024-08-28T16:32:54.4874244' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019740025, CAST(N'2024-08-28T16:32:54.8783560' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019750026, CAST(N'2024-08-28T16:32:55.2806414' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019750027, CAST(N'2024-08-28T16:32:55.7726559' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019760028, CAST(N'2024-08-28T16:32:56.1007574' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019760029, CAST(N'2024-08-28T16:32:56.5458715' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019770030, CAST(N'2024-08-28T16:32:57.0159096' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019770031, CAST(N'2024-08-28T16:32:57.5591876' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019770032, CAST(N'2024-08-28T16:32:57.9798078' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019780033, CAST(N'2024-08-28T16:32:58.3803345' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019780034, CAST(N'2024-08-28T16:32:58.9034204' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019790035, CAST(N'2024-08-28T16:32:59.4219855' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019790036, CAST(N'2024-08-28T16:32:59.9073727' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019800037, CAST(N'2024-08-28T16:33:00.3154544' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019800038, CAST(N'2024-08-28T16:33:00.7581460' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019810039, CAST(N'2024-08-28T16:33:01.1723033' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019810040, CAST(N'2024-08-28T16:33:01.6470134' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019820041, CAST(N'2024-08-28T16:33:02.0363911' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019820042, CAST(N'2024-08-28T16:33:02.8814439' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828019940001, CAST(N'2024-08-28T16:33:14.6763900' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828021910001, CAST(N'2024-08-28T16:36:31.6161361' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240828024000001, CAST(N'2024-08-28T16:40:00.7366658' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240918033480001, CAST(N'2024-09-18T17:55:48.0387667' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240918034180001, CAST(N'2024-09-18T17:56:58.5611276' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240920029610001, CAST(N'2024-09-20T15:49:21.9860955' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923006450001, CAST(N'2024-09-23T11:10:45.9551643' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923007220001, CAST(N'2024-09-23T11:12:02.0970323' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923007220002, CAST(N'2024-09-23T11:12:02.7287247' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923007230003, CAST(N'2024-09-23T11:12:03.2150896' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923007230004, CAST(N'2024-09-23T11:12:03.7309064' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (240923007240005, CAST(N'2024-09-23T11:12:04.2739515' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 240918012770001, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[1]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241031035440001, CAST(N'2024-10-31T15:59:04.2902920' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'022cd8ab-a079-4f65-902a-c67ef0678e37', 1, N'鲍氏大楼', N'{"appid":"022cd8ab-a079-4f65-902a-c67ef0678e37","ids":[2,3]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241031035880001, CAST(N'2024-10-31T15:59:48.3055821' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'022cd8ab-a079-4f65-902a-c67ef0678e37', 1, N'鲍氏大楼', N'{"appid":"022cd8ab-a079-4f65-902a-c67ef0678e37","ids":[2,5]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241031035940002, CAST(N'2024-10-31T15:59:54.8428720' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'022cd8ab-a079-4f65-902a-c67ef0678e37', 1, N'鲍氏大楼', N'{"appid":"022cd8ab-a079-4f65-902a-c67ef0678e37","ids":[2,5]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241031035960003, CAST(N'2024-10-31T15:59:56.8088364' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'022cd8ab-a079-4f65-902a-c67ef0678e37', 1, N'鲍氏大楼', N'{"appid":"022cd8ab-a079-4f65-902a-c67ef0678e37","ids":[2,5]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241031035980004, CAST(N'2024-10-31T15:59:58.1809913' AS DateTime2), CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'022cd8ab-a079-4f65-902a-c67ef0678e37', 1, N'鲍氏大楼', N'{"appid":"022cd8ab-a079-4f65-902a-c67ef0678e37","ids":[2,5]}', NULL)
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101009050001, CAST(N'2024-11-01T17:15:05.4113788' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-10-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101010880001, CAST(N'2024-11-01T17:18:08.6564209' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-10-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101010900002, CAST(N'2024-11-01T17:18:10.6352791' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-10-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101010910003, CAST(N'2024-11-01T17:18:11.3285469' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-11-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101010910004, CAST(N'2024-11-01T17:18:11.8745829' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-11-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101010920005, CAST(N'2024-11-01T17:18:12.4454668' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-11-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101011370001, CAST(N'2024-11-01T17:18:57.2817097' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-11-03T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Order] ([trade_no], [createTime], [amount], [payedAmount], [status], [objectId], [userId], [name], [extraInfo], [expireDate]) VALUES (241101011380002, CAST(N'2024-11-01T17:18:58.0769446' AS DateTime2), CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'鲍氏大楼', N'{"appid":"0140a5e3-e8a4-4383-9e83-b20a27ee7923","ids":[2]}', CAST(N'2024-11-03T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([_id], [createTime], [AppointmentId], [TUserId], [ticketNumber], [startTime], [endTime], [stauts], [userID], [objectId], [ota], [usedCount], [totalCount], [cancelCount], [verifyTime], [isMultiPart], [QRCode]) VALUES (1, CAST(N'2024-08-28T16:40:21.0219896' AS DateTime2), N'0140a5e3-e8a4-4383-9e83-b20a27ee7923', 1, N'17248344210221864536795', CAST(N'2024-08-30T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-30T23:59:59.0000000' AS DateTime2), 1, 1, 240828024000001, 0, 0, 1, 0, NULL, 0, NULL)
GO
INSERT [dbo].[Ticket] ([_id], [createTime], [AppointmentId], [TUserId], [ticketNumber], [startTime], [endTime], [stauts], [userID], [objectId], [ota], [usedCount], [totalCount], [cancelCount], [verifyTime], [isMultiPart], [QRCode]) VALUES (6, CAST(N'2024-08-28T16:40:21.0219896' AS DateTime2), N'0135209b-209f-4a42-a242-7255b50c10d7', 1, N'2', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2000-01-02T00:00:00.0000000' AS DateTime2), 3, 1, 240828019560004, 0, 0, 1, 0, NULL, NULL, NULL)
GO
INSERT [dbo].[Ticket] ([_id], [createTime], [AppointmentId], [TUserId], [ticketNumber], [startTime], [endTime], [stauts], [userID], [objectId], [ota], [usedCount], [totalCount], [cancelCount], [verifyTime], [isMultiPart], [QRCode]) VALUES (7, CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), N'0135209b-209f-4a42-a242-7255b50c10d7', 3, N'2', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), 3, 1, 240828019560004, 0, 0, 1, 0, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
INSERT [dbo].[User] ([id], [authLevel], [isDeleted], [CreateTime], [username], [password], [openId]) VALUES (1, 1, 0, CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), N'admin', N'afdd0b4ad2ec172c586e2150770fbf9e', NULL)
GO
INSERT [dbo].[User] ([id], [authLevel], [isDeleted], [CreateTime], [username], [password], [openId]) VALUES (240918012770001, 1, 0, CAST(N'2024-09-18T16:21:17.6967005' AS DateTime2), N'133711212771724673', N'-1', N'oLa1F6-22SdTs3DoAWklflmVnWCM')
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (1, N'user_1', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173927' AS DateTime2), 240918012770001)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (2, N'user_2', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173951' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (3, N'user_3', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173954' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (4, N'user_4', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173955' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (5, N'user_5', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173985' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (6, N'user_6', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173987' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (7, N'user_7', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173989' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (8, N'user_8', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173989' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (9, N'user_9', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173991' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (10, N'user_10', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173992' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (11, N'user_11', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173994' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (12, N'user_12', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173995' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (13, N'user_13', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173996' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (14, N'user_14', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173997' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (15, N'user_15', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173998' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (16, N'user_16', N'_', N'_', CAST(N'2024-01-23T14:37:05.5173999' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (17, N'user_17', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174000' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (18, N'user_18', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174002' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (19, N'user_19', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174003' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (20, N'user_20', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174004' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (21, N'user_21', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174005' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (22, N'user_22', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174006' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (23, N'user_23', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174007' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (24, N'user_24', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174008' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (25, N'user_25', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174009' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (26, N'user_26', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174009' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (27, N'user_27', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174010' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (28, N'user_28', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174011' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (29, N'user_29', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174012' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (30, N'user_30', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174013' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (31, N'user_31', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174014' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (32, N'user_32', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174015' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (33, N'user_33', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174016' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (34, N'user_34', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174018' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (35, N'user_35', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174019' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (36, N'user_36', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174020' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (37, N'user_37', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174021' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (38, N'user_38', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174021' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (39, N'user_39', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174022' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (40, N'user_40', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174023' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (41, N'user_41', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174024' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (42, N'user_42', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174025' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (43, N'user_43', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174026' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (44, N'user_44', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174027' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (45, N'user_45', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174028' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (46, N'user_46', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174029' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (47, N'user_47', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174030' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (48, N'user_48', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174031' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (49, N'user_49', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174031' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (50, N'user_50', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174033' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (51, N'user_51', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174033' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (52, N'user_52', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174034' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (53, N'user_53', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174057' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (54, N'user_54', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174058' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (55, N'user_55', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174059' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (56, N'user_56', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174060' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (57, N'user_57', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174061' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (58, N'user_58', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174062' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (59, N'user_59', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174063' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (60, N'user_60', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174064' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (61, N'user_61', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174065' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (62, N'user_62', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174066' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (63, N'user_63', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174067' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (64, N'user_64', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174068' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (65, N'user_65', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174069' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (66, N'user_66', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174071' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (67, N'user_67', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174072' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (68, N'user_68', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174073' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (69, N'user_69', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174074' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (70, N'user_70', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174075' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (71, N'user_71', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174076' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (72, N'user_72', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174076' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (73, N'user_73', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174077' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (74, N'user_74', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174078' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (75, N'user_75', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174079' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (76, N'user_76', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174080' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (77, N'user_77', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174081' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (78, N'user_78', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174082' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (79, N'user_79', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174083' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (80, N'user_80', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174084' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (81, N'user_81', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174085' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (82, N'user_82', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174086' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (83, N'user_83', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174087' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (84, N'user_84', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174087' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (85, N'user_85', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174088' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (86, N'user_86', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174089' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (87, N'user_87', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174090' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (88, N'user_88', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174091' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (89, N'user_89', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174092' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (90, N'user_90', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174093' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (91, N'user_91', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174094' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (92, N'user_92', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174095' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (93, N'user_93', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174096' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (94, N'user_94', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174097' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (95, N'user_95', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174098' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (96, N'user_96', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174099' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (97, N'user_97', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174100' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (98, N'user_98', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174101' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (99, N'user_99', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174102' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (100, N'user_100', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174126' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (101, N'user_101', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174127' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (102, N'user_102', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174128' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (103, N'user_103', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174129' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (104, N'user_104', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174130' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (105, N'user_105', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174131' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (106, N'user_106', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174133' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (107, N'user_107', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174134' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (108, N'user_108', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174135' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (109, N'user_109', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174135' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (110, N'user_110', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174136' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (111, N'user_111', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174137' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (112, N'user_112', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174138' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (113, N'user_113', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174139' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (114, N'user_114', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174140' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (115, N'user_115', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174141' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (116, N'user_116', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174142' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (117, N'user_117', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174143' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (118, N'user_118', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174144' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (119, N'user_119', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174145' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (120, N'user_120', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174146' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (121, N'user_121', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174147' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (122, N'user_122', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174148' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (123, N'user_123', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174148' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (124, N'user_124', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174149' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (125, N'user_125', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174150' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (126, N'user_126', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174151' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (127, N'user_127', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174152' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (128, N'user_128', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174153' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (129, N'user_129', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174154' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (130, N'user_130', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174156' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (131, N'user_131', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174157' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (132, N'user_132', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174158' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (133, N'user_133', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174159' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (134, N'user_134', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174160' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (135, N'user_135', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174161' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (136, N'user_136', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174161' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (137, N'user_137', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174162' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (138, N'user_138', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174163' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (139, N'user_139', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174164' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (140, N'user_140', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174195' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (141, N'user_141', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174196' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (142, N'user_142', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174197' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (143, N'user_143', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174198' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (144, N'user_144', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174199' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (145, N'user_145', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174200' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (146, N'user_146', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174201' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (147, N'user_147', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174202' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (148, N'user_148', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174203' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (149, N'user_149', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174204' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (150, N'user_150', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174205' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (151, N'user_151', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174205' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (152, N'user_152', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174206' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (153, N'user_153', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174207' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (154, N'user_154', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174208' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (155, N'user_155', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174209' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (156, N'user_156', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174210' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (157, N'user_157', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174211' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (158, N'user_158', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174212' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (159, N'user_159', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174213' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (160, N'user_160', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174214' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (161, N'user_161', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174215' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (162, N'user_162', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174216' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (163, N'user_163', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174217' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (164, N'user_164', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174218' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (165, N'user_165', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174219' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (166, N'user_166', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174220' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (167, N'user_167', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174221' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (168, N'user_168', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174222' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (169, N'user_169', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174223' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (170, N'user_170', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174223' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (171, N'user_171', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174224' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (172, N'user_172', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174225' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (173, N'user_173', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174226' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (174, N'user_174', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174227' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (175, N'user_175', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174228' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (176, N'user_176', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174229' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (177, N'user_177', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174230' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (178, N'user_178', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174231' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (179, N'user_179', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174232' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (180, N'user_180', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174233' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (181, N'user_181', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174233' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (182, N'user_182', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174234' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (183, N'user_183', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174235' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (184, N'user_184', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174236' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (185, N'user_185', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174237' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (186, N'user_186', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174238' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (187, N'user_187', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174239' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (188, N'user_188', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174240' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (189, N'user_189', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174241' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (190, N'user_190', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174242' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (191, N'user_191', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174243' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (192, N'user_192', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174244' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (193, N'user_193', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174266' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (194, N'user_194', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174268' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (195, N'user_195', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174269' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (196, N'user_196', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174270' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (197, N'user_197', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174271' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (198, N'user_198', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174272' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (199, N'user_199', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174273' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (200, N'user_200', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174274' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (201, N'user_201', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174275' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (202, N'user_202', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174276' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (203, N'user_203', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174277' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (204, N'user_204', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174278' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (205, N'user_205', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174279' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (206, N'user_206', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174280' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (207, N'user_207', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174281' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (208, N'user_208', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174282' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (209, N'user_209', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174283' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (210, N'user_210', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174284' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (211, N'user_211', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174285' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (212, N'user_212', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174286' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (213, N'user_213', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174287' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (214, N'user_214', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174287' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (215, N'user_215', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174288' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (216, N'user_216', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174289' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (217, N'user_217', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174290' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (218, N'user_218', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174291' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (219, N'user_219', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174292' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (220, N'user_220', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174293' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (221, N'user_221', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174294' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (222, N'user_222', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174295' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (223, N'user_223', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174296' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (224, N'user_224', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174297' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (225, N'user_225', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174298' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (226, N'user_226', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174299' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (227, N'user_227', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174300' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (228, N'user_228', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174301' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (229, N'user_229', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174302' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (230, N'user_230', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174302' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (231, N'user_231', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174303' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (232, N'user_232', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174304' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (233, N'user_233', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174305' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (234, N'user_234', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174306' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (235, N'user_235', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174307' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (236, N'user_236', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174308' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (237, N'user_237', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174309' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (238, N'user_238', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174310' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (239, N'user_239', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174311' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (240, N'user_240', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174312' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (241, N'user_241', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174313' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (242, N'user_242', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174314' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (243, N'user_243', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174314' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (244, N'user_244', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174315' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (245, N'user_245', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174316' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (246, N'user_246', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174317' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (247, N'user_247', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174359' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (248, N'user_248', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174360' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (249, N'user_249', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174362' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (250, N'user_250', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174362' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (251, N'user_251', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174363' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (252, N'user_252', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174364' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (253, N'user_253', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174365' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (254, N'user_254', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174366' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (255, N'user_255', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174368' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (256, N'user_256', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174368' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (257, N'user_257', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174369' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (258, N'user_258', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174372' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (259, N'user_259', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174373' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (260, N'user_260', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174374' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (261, N'user_261', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174374' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (262, N'user_262', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174375' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (263, N'user_263', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174376' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (264, N'user_264', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174377' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (265, N'user_265', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174378' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (266, N'user_266', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174379' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (267, N'user_267', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174380' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (268, N'user_268', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174381' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (269, N'user_269', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174382' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (270, N'user_270', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174383' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (271, N'user_271', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174384' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (272, N'user_272', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174385' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (273, N'user_273', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174386' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (274, N'user_274', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174416' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (275, N'user_275', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174417' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (276, N'user_276', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174418' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (277, N'user_277', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174419' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (278, N'user_278', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174420' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (279, N'user_279', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174421' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (280, N'user_280', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174422' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (281, N'user_281', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174423' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (282, N'user_282', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174424' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (283, N'user_283', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174425' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (284, N'user_284', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174426' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (285, N'user_285', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174427' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (286, N'user_286', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174428' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (287, N'user_287', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174429' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (288, N'user_288', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174430' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (289, N'user_289', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174431' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (290, N'user_290', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174432' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (291, N'user_291', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174433' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (292, N'user_292', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174434' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (293, N'user_293', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174435' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (294, N'user_294', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174435' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (295, N'user_295', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174436' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (296, N'user_296', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174437' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (297, N'user_297', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174438' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (298, N'user_298', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174439' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (299, N'user_299', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174440' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (300, N'user_300', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174441' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (301, N'user_301', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174442' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (302, N'user_302', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174443' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (303, N'user_303', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174444' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (304, N'user_304', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174445' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (305, N'user_305', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174446' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (306, N'user_306', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174447' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (307, N'user_307', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174448' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (308, N'user_308', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174449' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (309, N'user_309', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174449' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (310, N'user_310', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174450' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (311, N'user_311', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174451' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (312, N'user_312', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174452' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (313, N'user_313', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174453' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (314, N'user_314', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174454' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (315, N'user_315', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174455' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (316, N'user_316', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174456' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (317, N'user_317', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174457' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (318, N'user_318', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174458' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (319, N'user_319', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174459' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (320, N'user_320', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174460' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (321, N'user_321', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174461' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (322, N'user_322', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174461' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (323, N'user_323', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174462' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (324, N'user_324', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174463' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (325, N'user_325', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174464' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (326, N'user_326', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174465' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (327, N'user_327', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174489' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (328, N'user_328', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174491' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (329, N'user_329', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174492' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (330, N'user_330', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174493' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (331, N'user_331', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174494' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (332, N'user_332', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174495' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (333, N'user_333', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174496' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (334, N'user_334', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174496' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (335, N'user_335', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174497' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (336, N'user_336', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174498' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (337, N'user_337', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174499' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (338, N'user_338', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174500' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (339, N'user_339', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174501' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (340, N'user_340', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174502' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (341, N'user_341', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174503' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (342, N'user_342', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174504' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (343, N'user_343', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174505' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (344, N'user_344', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174506' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (345, N'user_345', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174507' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (346, N'user_346', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174508' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (347, N'user_347', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174509' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (348, N'user_348', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174510' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (349, N'user_349', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174511' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (350, N'user_350', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174512' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (351, N'user_351', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174513' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (352, N'user_352', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174514' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (353, N'user_353', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174515' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (354, N'user_354', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174516' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (355, N'user_355', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174517' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (356, N'user_356', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174518' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (357, N'user_357', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174519' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (358, N'user_358', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174519' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (359, N'user_359', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174520' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (360, N'user_360', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174521' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (361, N'user_361', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174522' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (362, N'user_362', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174523' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (363, N'user_363', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174524' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (364, N'user_364', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174525' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (365, N'user_365', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174526' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (366, N'user_366', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174527' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (367, N'user_367', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174528' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (368, N'user_368', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174529' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (369, N'user_369', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174530' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (370, N'user_370', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174531' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (371, N'user_371', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174532' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (372, N'user_372', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174533' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (373, N'user_373', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174534' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (374, N'user_374', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174535' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (375, N'user_375', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174535' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (376, N'user_376', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174536' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (377, N'user_377', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174537' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (378, N'user_378', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174538' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (379, N'user_379', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174539' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (380, N'user_380', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174540' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (381, N'user_381', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174564' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (382, N'user_382', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174565' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (383, N'user_383', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174566' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (384, N'user_384', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174567' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (385, N'user_385', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174568' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (386, N'user_386', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174569' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (387, N'user_387', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174570' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (388, N'user_388', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174571' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (389, N'user_389', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174572' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (390, N'user_390', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174573' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (391, N'user_391', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174574' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (392, N'user_392', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174575' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (393, N'user_393', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174576' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (394, N'user_394', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174577' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (395, N'user_395', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174578' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (396, N'user_396', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174579' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (397, N'user_397', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174580' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (398, N'user_398', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174580' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (399, N'user_399', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174582' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (400, N'user_400', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174583' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (401, N'user_401', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174583' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (402, N'user_402', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174584' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (403, N'user_403', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174585' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (404, N'user_404', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174586' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (405, N'user_405', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174587' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (406, N'user_406', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174588' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (407, N'user_407', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174589' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (408, N'user_408', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174590' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (409, N'user_409', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174591' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (410, N'user_410', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174592' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (411, N'user_411', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174593' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (412, N'user_412', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174594' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (413, N'user_413', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174595' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (414, N'user_414', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174595' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (415, N'user_415', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174596' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (416, N'user_416', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174597' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (417, N'user_417', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174598' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (418, N'user_418', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174599' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (419, N'user_419', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174600' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (420, N'user_420', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174601' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (421, N'user_421', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174602' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (422, N'user_422', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174603' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (423, N'user_423', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174604' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (424, N'user_424', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174605' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (425, N'user_425', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174606' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (426, N'user_426', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174607' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (427, N'user_427', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174608' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (428, N'user_428', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174609' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (429, N'user_429', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174610' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (430, N'user_430', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174610' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (431, N'user_431', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174612' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (432, N'user_432', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174613' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (433, N'user_433', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174613' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (434, N'user_434', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174614' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (435, N'user_435', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174648' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (436, N'user_436', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174649' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (437, N'user_437', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174650' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (438, N'user_438', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174651' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (439, N'user_439', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174652' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (440, N'user_440', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174653' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (441, N'user_441', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174654' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (442, N'user_442', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174655' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (443, N'user_443', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174656' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (444, N'user_444', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174657' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (445, N'user_445', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174658' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (446, N'user_446', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174659' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (447, N'user_447', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174660' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (448, N'user_448', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174660' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (449, N'user_449', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174661' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (450, N'user_450', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174663' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (451, N'user_451', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174664' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (452, N'user_452', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174664' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (453, N'user_453', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174665' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (454, N'user_454', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174666' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (455, N'user_455', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174667' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (456, N'user_456', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174668' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (457, N'user_457', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174669' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (458, N'user_458', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174670' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (459, N'user_459', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174671' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (460, N'user_460', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174672' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (461, N'user_461', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174673' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (462, N'user_462', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174674' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (463, N'user_463', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174675' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (464, N'user_464', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174676' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (465, N'user_465', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174677' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (466, N'user_466', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174677' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (467, N'user_467', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174679' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (468, N'user_468', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174680' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (469, N'user_469', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174680' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (470, N'user_470', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174681' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (471, N'user_471', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174682' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (472, N'user_472', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174683' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (473, N'user_473', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174684' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (474, N'user_474', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174685' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (475, N'user_475', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174686' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (476, N'user_476', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174687' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (477, N'user_477', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174688' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (478, N'user_478', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174689' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (479, N'user_479', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174690' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (480, N'user_480', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174691' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (481, N'user_481', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174692' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (482, N'user_482', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174693' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (483, N'user_483', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174693' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (484, N'user_484', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174694' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (485, N'user_485', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174695' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (486, N'user_486', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174696' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (487, N'user_487', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174697' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (488, N'user_488', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174698' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (489, N'user_489', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174722' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (490, N'user_490', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174723' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (491, N'user_491', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174723' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (492, N'user_492', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174724' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (493, N'user_493', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174725' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (494, N'user_494', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174726' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (495, N'user_495', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174727' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (496, N'user_496', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174728' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (497, N'user_497', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174729' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (498, N'user_498', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174730' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (499, N'user_499', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174731' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (500, N'user_500', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174732' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (501, N'user_501', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174733' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (502, N'user_502', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174734' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (503, N'user_503', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174735' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (504, N'user_504', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174736' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (505, N'user_505', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174737' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (506, N'user_506', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174737' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (507, N'user_507', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174738' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (508, N'user_508', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174739' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (509, N'user_509', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174740' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (510, N'user_510', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174741' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (511, N'user_511', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174742' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (512, N'user_512', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174743' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (513, N'user_513', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174744' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (514, N'user_514', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174782' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (515, N'user_515', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174784' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (516, N'user_516', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174785' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (517, N'user_517', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174786' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (518, N'user_518', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174787' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (519, N'user_519', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174787' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (520, N'user_520', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174789' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (521, N'user_521', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174790' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (522, N'user_522', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174791' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (523, N'user_523', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174792' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (524, N'user_524', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174793' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (525, N'user_525', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174794' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (526, N'user_526', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174795' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (527, N'user_527', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174796' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (528, N'user_528', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174796' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (529, N'user_529', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174797' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (530, N'user_530', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174798' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (531, N'user_531', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174799' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (532, N'user_532', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174800' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (533, N'user_533', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174801' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (534, N'user_534', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174802' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (535, N'user_535', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174803' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (536, N'user_536', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174804' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (537, N'user_537', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174805' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (538, N'user_538', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174806' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (539, N'user_539', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174807' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (540, N'user_540', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174808' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (541, N'user_541', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174809' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (542, N'user_542', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174823' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (543, N'user_543', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174825' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (544, N'user_544', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174826' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (545, N'user_545', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174826' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (546, N'user_546', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174827' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (547, N'user_547', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174828' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (548, N'user_548', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174830' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (549, N'user_549', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174830' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (550, N'user_550', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174832' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (551, N'user_551', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174833' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (552, N'user_552', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174834' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (553, N'user_553', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174835' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (554, N'user_554', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174836' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (555, N'user_555', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174836' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (556, N'user_556', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174837' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (557, N'user_557', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174838' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (558, N'user_558', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174839' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (559, N'user_559', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174840' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (560, N'user_560', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174841' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (561, N'user_561', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174842' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (562, N'user_562', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174843' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (563, N'user_563', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174844' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (564, N'user_564', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174845' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (565, N'user_565', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174846' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (566, N'user_566', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174847' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (567, N'user_567', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174848' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (568, N'user_568', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174849' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (569, N'user_569', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174849' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (570, N'user_570', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174850' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (571, N'user_571', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174851' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (572, N'user_572', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174852' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (573, N'user_573', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174853' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (574, N'user_574', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174854' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (575, N'user_575', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174855' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (576, N'user_576', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174856' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (577, N'user_577', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174857' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (578, N'user_578', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174858' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (579, N'user_579', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174859' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (580, N'user_580', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174860' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (581, N'user_581', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174861' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (582, N'user_582', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174862' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (583, N'user_583', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174863' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (584, N'user_584', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174863' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (585, N'user_585', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174864' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (586, N'user_586', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174865' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (587, N'user_587', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174866' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (588, N'user_588', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174867' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (589, N'user_589', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174868' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (590, N'user_590', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174869' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (591, N'user_591', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174870' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (592, N'user_592', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174871' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (593, N'user_593', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174872' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (594, N'user_594', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174873' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (595, N'user_595', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174874' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (596, N'user_596', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174911' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (597, N'user_597', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174912' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (598, N'user_598', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174913' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (599, N'user_599', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174914' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (600, N'user_600', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174915' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (601, N'user_601', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174916' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (602, N'user_602', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174917' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (603, N'user_603', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174918' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (604, N'user_604', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174919' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (605, N'user_605', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174919' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (606, N'user_606', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174920' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (607, N'user_607', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174921' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (608, N'user_608', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174922' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (609, N'user_609', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174923' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (610, N'user_610', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174924' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (611, N'user_611', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174925' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (612, N'user_612', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174926' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (613, N'user_613', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174927' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (614, N'user_614', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174928' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (615, N'user_615', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174929' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (616, N'user_616', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174930' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (617, N'user_617', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174931' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (618, N'user_618', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174931' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (619, N'user_619', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174932' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (620, N'user_620', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174933' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (621, N'user_621', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174934' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (622, N'user_622', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174935' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (623, N'user_623', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174936' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (624, N'user_624', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174937' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (625, N'user_625', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174938' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (626, N'user_626', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174939' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (627, N'user_627', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174940' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (628, N'user_628', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174941' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (629, N'user_629', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174942' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (630, N'user_630', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174943' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (631, N'user_631', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174943' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (632, N'user_632', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174944' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (633, N'user_633', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174945' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (634, N'user_634', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174946' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (635, N'user_635', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174947' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (636, N'user_636', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174948' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (637, N'user_637', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174949' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (638, N'user_638', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174950' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (639, N'user_639', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174951' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (640, N'user_640', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174952' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (641, N'user_641', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174953' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (642, N'user_642', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174953' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (643, N'user_643', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174954' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (644, N'user_644', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174955' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (645, N'user_645', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174956' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (646, N'user_646', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174957' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (647, N'user_647', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174958' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (648, N'user_648', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174959' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (649, N'user_649', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174960' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (650, N'user_650', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174984' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (651, N'user_651', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174985' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (652, N'user_652', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174986' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (653, N'user_653', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174987' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (654, N'user_654', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174988' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (655, N'user_655', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174989' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (656, N'user_656', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174990' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (657, N'user_657', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174991' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (658, N'user_658', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174991' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (659, N'user_659', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174992' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (660, N'user_660', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174993' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (661, N'user_661', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174994' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (662, N'user_662', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174995' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (663, N'user_663', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174996' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (664, N'user_664', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174997' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (665, N'user_665', N'_', N'_', CAST(N'2024-01-23T14:37:05.5174999' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (666, N'user_666', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175000' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (667, N'user_667', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175001' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (668, N'user_668', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175002' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (669, N'user_669', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175002' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (670, N'user_670', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175003' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (671, N'user_671', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175004' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (672, N'user_672', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175005' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (673, N'user_673', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175006' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (674, N'user_674', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175007' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (675, N'user_675', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175008' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (676, N'user_676', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175009' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (677, N'user_677', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175010' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (678, N'user_678', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175011' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (679, N'user_679', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175012' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (680, N'user_680', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175013' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (681, N'user_681', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175014' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (682, N'user_682', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175014' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (683, N'user_683', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175015' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (684, N'user_684', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175017' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (685, N'user_685', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175017' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (686, N'user_686', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175018' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (687, N'user_687', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175019' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (688, N'user_688', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175020' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (689, N'user_689', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175021' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (690, N'user_690', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175022' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (691, N'user_691', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175023' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (692, N'user_692', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175024' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (693, N'user_693', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175025' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (694, N'user_694', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175026' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (695, N'user_695', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175027' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (696, N'user_696', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175028' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (697, N'user_697', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175029' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (698, N'user_698', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175030' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (699, N'user_699', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175031' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (700, N'user_700', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175032' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (701, N'user_701', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175033' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (702, N'user_702', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175034' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (703, N'user_703', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175057' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (704, N'user_704', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175058' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (705, N'user_705', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175059' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (706, N'user_706', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175060' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (707, N'user_707', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175061' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (708, N'user_708', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175062' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (709, N'user_709', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175063' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (710, N'user_710', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175064' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (711, N'user_711', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175065' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (712, N'user_712', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175066' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (713, N'user_713', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175067' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (714, N'user_714', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175068' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (715, N'user_715', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175069' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (716, N'user_716', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175070' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (717, N'user_717', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175071' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (718, N'user_718', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175072' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (719, N'user_719', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175073' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (720, N'user_720', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175073' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (721, N'user_721', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175074' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (722, N'user_722', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175075' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (723, N'user_723', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175076' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (724, N'user_724', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175077' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (725, N'user_725', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175078' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (726, N'user_726', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175079' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (727, N'user_727', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175080' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (728, N'user_728', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175081' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (729, N'user_729', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175082' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (730, N'user_730', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175083' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (731, N'user_731', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175084' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (732, N'user_732', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175085' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (733, N'user_733', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175086' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (734, N'user_734', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175087' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (735, N'user_735', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175087' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (736, N'user_736', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175088' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (737, N'user_737', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175089' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (738, N'user_738', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175090' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (739, N'user_739', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175091' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (740, N'user_740', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175092' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (741, N'user_741', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175093' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (742, N'user_742', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175094' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (743, N'user_743', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175095' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (744, N'user_744', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175096' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (745, N'user_745', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175097' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (746, N'user_746', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175098' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (747, N'user_747', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175099' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (748, N'user_748', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175100' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (749, N'user_749', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175101' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (750, N'user_750', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175102' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (751, N'user_751', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175103' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (752, N'user_752', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175104' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (753, N'user_753', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175105' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (754, N'user_754', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175106' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (755, N'user_755', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175107' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (756, N'user_756', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175108' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (757, N'user_757', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175131' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (758, N'user_758', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175133' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (759, N'user_759', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175134' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (760, N'user_760', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175135' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (761, N'user_761', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175136' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (762, N'user_762', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175137' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (763, N'user_763', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175138' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (764, N'user_764', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175139' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (765, N'user_765', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175140' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (766, N'user_766', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175141' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (767, N'user_767', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175142' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (768, N'user_768', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175143' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (769, N'user_769', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175143' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (770, N'user_770', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175144' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (771, N'user_771', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175146' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (772, N'user_772', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175146' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (773, N'user_773', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175147' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (774, N'user_774', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175148' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (775, N'user_775', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175149' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (776, N'user_776', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175150' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (777, N'user_777', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175151' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (778, N'user_778', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175152' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (779, N'user_779', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175153' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (780, N'user_780', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175154' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (781, N'user_781', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175155' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (782, N'user_782', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175156' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (783, N'user_783', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175156' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (784, N'user_784', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175157' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (785, N'user_785', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175158' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (786, N'user_786', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175159' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (787, N'user_787', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175160' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (788, N'user_788', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175161' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (789, N'user_789', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175162' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (790, N'user_790', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175163' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (791, N'user_791', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175164' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (792, N'user_792', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175165' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (793, N'user_793', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175166' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (794, N'user_794', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175167' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (795, N'user_795', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175168' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (796, N'user_796', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175168' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (797, N'user_797', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175169' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (798, N'user_798', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175170' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (799, N'user_799', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175171' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (800, N'user_800', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175172' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (801, N'user_801', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175173' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (802, N'user_802', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175174' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (803, N'user_803', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175175' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (804, N'user_804', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175176' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (805, N'user_805', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175177' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (806, N'user_806', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175177' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (807, N'user_807', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175178' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (808, N'user_808', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175179' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (809, N'user_809', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175180' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (810, N'user_810', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175181' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (811, N'user_811', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175207' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (812, N'user_812', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175209' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (813, N'user_813', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175209' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (814, N'user_814', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175210' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (815, N'user_815', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175211' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (816, N'user_816', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175212' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (817, N'user_817', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175213' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (818, N'user_818', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175214' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (819, N'user_819', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175215' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (820, N'user_820', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175216' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (821, N'user_821', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175217' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (822, N'user_822', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175218' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (823, N'user_823', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175219' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (824, N'user_824', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175220' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (825, N'user_825', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175221' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (826, N'user_826', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175222' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (827, N'user_827', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175223' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (828, N'user_828', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175223' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (829, N'user_829', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175225' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (830, N'user_830', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175226' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (831, N'user_831', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175226' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (832, N'user_832', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175227' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (833, N'user_833', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175228' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (834, N'user_834', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175229' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (835, N'user_835', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175230' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (836, N'user_836', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175231' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (837, N'user_837', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175232' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (838, N'user_838', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175233' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (839, N'user_839', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175234' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (840, N'user_840', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175235' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (841, N'user_841', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175236' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (842, N'user_842', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175237' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (843, N'user_843', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175238' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (844, N'user_844', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175239' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (845, N'user_845', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175240' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (846, N'user_846', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175241' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (847, N'user_847', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175242' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (848, N'user_848', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175242' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (849, N'user_849', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175243' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (850, N'user_850', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175244' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (851, N'user_851', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175245' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (852, N'user_852', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175246' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (853, N'user_853', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175247' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (854, N'user_854', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175248' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (855, N'user_855', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175249' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (856, N'user_856', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175250' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (857, N'user_857', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175251' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (858, N'user_858', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175251' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (859, N'user_859', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175252' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (860, N'user_860', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175253' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (861, N'user_861', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175254' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (862, N'user_862', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175255' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (863, N'user_863', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175256' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (864, N'user_864', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175257' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (865, N'user_865', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175286' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (866, N'user_866', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175287' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (867, N'user_867', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175288' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (868, N'user_868', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175289' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (869, N'user_869', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175290' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (870, N'user_870', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175291' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (871, N'user_871', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175291' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (872, N'user_872', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175292' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (873, N'user_873', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175293' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (874, N'user_874', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175294' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (875, N'user_875', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175295' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (876, N'user_876', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175296' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (877, N'user_877', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175297' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (878, N'user_878', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175298' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (879, N'user_879', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175299' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (880, N'user_880', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175300' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (881, N'user_881', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175301' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (882, N'user_882', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175302' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (883, N'user_883', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175303' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (884, N'user_884', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175304' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (885, N'user_885', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175304' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (886, N'user_886', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175305' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (887, N'user_887', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175306' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (888, N'user_888', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175307' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (889, N'user_889', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175308' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (890, N'user_890', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175309' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (891, N'user_891', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175310' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (892, N'user_892', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175311' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (893, N'user_893', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175312' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (894, N'user_894', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175313' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (895, N'user_895', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175314' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (896, N'user_896', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175315' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (897, N'user_897', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175316' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (898, N'user_898', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175317' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (899, N'user_899', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175318' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (900, N'user_900', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175318' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (901, N'user_901', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175319' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (902, N'user_902', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175320' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (903, N'user_903', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175321' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (904, N'user_904', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175322' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (905, N'user_905', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175323' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (906, N'user_906', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175324' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (907, N'user_907', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175325' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (908, N'user_908', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175326' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (909, N'user_909', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175327' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (910, N'user_910', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175328' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (911, N'user_911', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175329' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (912, N'user_912', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175330' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (913, N'user_913', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175331' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (914, N'user_914', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175332' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (915, N'user_915', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175333' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (916, N'user_916', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175334' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (917, N'user_917', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175334' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (918, N'user_918', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175361' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (919, N'user_919', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175363' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (920, N'user_920', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175364' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (921, N'user_921', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175365' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (922, N'user_922', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175366' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (923, N'user_923', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175367' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (924, N'user_924', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175368' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (925, N'user_925', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175369' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (926, N'user_926', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175370' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (927, N'user_927', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175371' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (928, N'user_928', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175372' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (929, N'user_929', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175373' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (930, N'user_930', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175374' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (931, N'user_931', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175375' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (932, N'user_932', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175376' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (933, N'user_933', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175377' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (934, N'user_934', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175378' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (935, N'user_935', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175379' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (936, N'user_936', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175380' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (937, N'user_937', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175380' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (938, N'user_938', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175381' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (939, N'user_939', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175382' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (940, N'user_940', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175383' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (941, N'user_941', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175384' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (942, N'user_942', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175385' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (943, N'user_943', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175386' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (944, N'user_944', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175387' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (945, N'user_945', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175388' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (946, N'user_946', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175389' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (947, N'user_947', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175390' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (948, N'user_948', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175391' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (949, N'user_949', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175392' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (950, N'user_950', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175392' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (951, N'user_951', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175394' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (952, N'user_952', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175395' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (953, N'user_953', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175395' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (954, N'user_954', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175396' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (955, N'user_955', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175397' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (956, N'user_956', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175398' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (957, N'user_957', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175399' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (958, N'user_958', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175400' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (959, N'user_959', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175401' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (960, N'user_960', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175402' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (961, N'user_961', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175403' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (962, N'user_962', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175404' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (963, N'user_963', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175405' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (964, N'user_964', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175406' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (965, N'user_965', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175407' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (966, N'user_966', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175408' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (967, N'user_967', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175409' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (968, N'user_968', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175409' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (969, N'user_969', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175410' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (970, N'user_970', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175411' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (971, N'user_971', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175412' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (972, N'user_972', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175438' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (973, N'user_973', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175440' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (974, N'user_974', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175441' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (975, N'user_975', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175441' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (976, N'user_976', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175443' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (977, N'user_977', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175444' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (978, N'user_978', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175445' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (979, N'user_979', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175445' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (980, N'user_980', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175446' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (981, N'user_981', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175447' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (982, N'user_982', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175448' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (983, N'user_983', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175449' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (984, N'user_984', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175450' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (985, N'user_985', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175451' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (986, N'user_986', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175452' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (987, N'user_987', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175453' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (988, N'user_988', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175454' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (989, N'user_989', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175455' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (990, N'user_990', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175455' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (991, N'user_991', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175456' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (992, N'user_992', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175457' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (993, N'user_993', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175458' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (994, N'user_994', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175459' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (995, N'user_995', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175460' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (996, N'user_996', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175461' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (997, N'user_997', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175462' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (998, N'user_998', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175463' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (999, N'user_999', N'_', N'_', CAST(N'2024-01-23T14:37:05.5175464' AS DateTime2), 1)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (241029029900001, N'string', N'string', N'string', CAST(N'2024-10-29T08:46:52.7610000' AS DateTime2), 240918012770001)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (241029029970002, N'string', N'string', N'string', CAST(N'2024-10-29T08:46:52.7610000' AS DateTime2), 240918012770001)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (241029030030003, N'string', N'string', N'string', CAST(N'2024-10-29T08:46:52.7610000' AS DateTime2), 240918012770001)
GO
INSERT [dbo].[UserInfo] ([id], [name], [phoneNumber], [idCard], [createTime], [userID]) VALUES (241029030090004, N'string', N'string', N'string', CAST(N'2024-10-29T08:46:52.7610000' AS DateTime2), 240918012770001)
GO
INSERT [dbo].[WebRouteConfig] ([id], [keyPath], [routePath]) VALUES (1, N'/web', N'/anfeng/1.txt')
GO
INSERT [dbo].[WebRouteConfig] ([id], [keyPath], [routePath]) VALUES (2, N'/dist', N'/anfeng/2.txt')
GO
INSERT [dbo].[WebRouteConfig] ([id], [keyPath], [routePath]) VALUES (3, N'/', N'/anfeng/1.txt')
GO
INSERT [dbo].[WechatBill] ([paymentId], [sourceId], [payTitle], [money], [userId], [type], [status], [paymentCode], [ip], [parameters], [payedMsg], [tradeNo], [createTime], [updateTime], [Attach], [transactionId]) VALUES (240918020110001, NULL, N'鲍氏大楼', CAST(10.00 AS Decimal(18, 2)), 240918012770001, 0, 2, N'JSAPI', N'0.0.0.1', NULL, NULL, 240828019540001, CAST(N'2024-10-28T16:33:32.3010736' AS DateTime2), CAST(N'2024-09-18T17:04:52.3431728' AS DateTime2), N'{"trade_no":240828019540001,"tenant_id":"anfeng"}', NULL)
GO
INSERT [dbo].[WechatBill] ([paymentId], [sourceId], [payTitle], [money], [userId], [type], [status], [paymentCode], [ip], [parameters], [payedMsg], [tradeNo], [createTime], [updateTime], [Attach], [transactionId]) VALUES (240920029700001, NULL, N'鲍氏大楼', CAST(10.00 AS Decimal(18, 2)), 240918012770001, 0, 2, N'JSAPI', N'0.0.0.1', NULL, NULL, 240920029610001, CAST(N'2024-10-28T16:33:32.3010736' AS DateTime2), CAST(N'2024-09-20T15:50:23.0704670' AS DateTime2), N'{"trade_no":240920029610001,"tenant_id":"anfeng"}', NULL)
GO
INSERT [dbo].[WechatBill] ([paymentId], [sourceId], [payTitle], [money], [userId], [type], [status], [paymentCode], [ip], [parameters], [payedMsg], [tradeNo], [createTime], [updateTime], [Attach], [transactionId]) VALUES (240920031850001, NULL, N'鲍氏大楼', CAST(10.00 AS Decimal(18, 2)), 240918012770001, 0, 2, N'JSAPI', N'0.0.0.1', NULL, NULL, 240828019540001, CAST(N'2024-10-28T16:33:32.3010736' AS DateTime2), CAST(N'2024-09-20T16:41:38.8637359' AS DateTime2), N'{"trade_no":240828019540001,"tenant_id":"anfeng"}', NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920015940001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 2, NULL, CAST(N'2024-09-20T17:26:34.9338383' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920016050001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 2, NULL, CAST(N'2024-09-20T17:26:45.2292683' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920016150001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 2, NULL, CAST(N'2024-09-20T17:26:55.3811887' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920016330001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 2, NULL, CAST(N'2024-09-20T17:27:13.4289761' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920016430001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 2, NULL, CAST(N'2024-09-20T17:27:23.5577552' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (240920018160001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 1, NULL, CAST(N'2024-09-20T17:30:16.5465419' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatBillRefund] ([refundId], [aftersalesId], [money], [userId], [sourceId], [paymentCode], [tradeNo], [status], [memo], [createTime], [updateTime]) VALUES (241028018480001, NULL, CAST(10.00 AS Decimal(18, 2)), 0, NULL, N'JSAPI', 240920031850001, 0, NULL, CAST(N'2024-10-28T16:30:49.0066733' AS DateTime2), NULL)
GO
INSERT [dbo].[WechatMerchantConfig] ([appid], [mchId], [apiKey], [apiv3Key], [certificate], [rsaPublicKey]) VALUES (N'wxd4d914a9a974b8ab', N'1559356071', N'wwsj7896541237896541237896541237', NULL, N'WxPayCert\apiclient_cert.p12', NULL)
GO
INSERT [dbo].[XieChengConfig] ([Account], [ApiKey], [AESKey], [AESVector]) VALUES (N'e897b9cae409292a', N'34af62adab971819b8e3ec235b286fda', N'ebaa67fc50fc002b', N'ed33ed430149efe3')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728291', 240417000440016, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3661519' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'101928274', 2, 0, 5, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728298', 240417000440008, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3661253' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'168089033', 2, 0, 5, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728305', 240417000440001, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3660552' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'108825657', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728312', 240417000440017, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3655511' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'186369166', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728319', 240417000440005, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3656804' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'190511025', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728326', 240417000440020, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3655874' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'143945524', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728333', 240417000440018, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3655155' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'113389033', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728340', 240417000440003, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3665933' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'100152907', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728347', 240417000440007, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3655283' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'146104765', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728354', 240417000440012, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3661738' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'104538274', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728361', 240417000440015, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3658805' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'188862873', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728368', 240417000440010, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3657224' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'102552907', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728375', 240417000440014, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3658293' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728382', 240417000440021, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3665573' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728389', 240417000440004, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3656998' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728396', 240417000440002, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3658057' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728403', 240417000440011, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3665341' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'154062907', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728410', 240417000440013, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3661982' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'103396416', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728417', 240417000440006, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3656423' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'107148274', 1, 0, 4, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728424', 240417000440019, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3664671' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'129372873', 0, 0, 13, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728431', 240417000440009, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:00:44.3664307' AS DateTime2), N'2024-04-30', N'2024-04-30', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd8759291-6149-4bdf-b9f3-cc48881ce17c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'169845657', 1, 0, 4, N'20240417170011697_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728438', 240417002630002, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3622015' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'149696416', 2, 0, 5, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728445', 240417002630008, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4145324' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'159821025', 2, 0, 5, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728452', 240417002630001, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3373396' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'186065524', 0, 1, 7, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728459', 240417002630003, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3618759' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'144355657', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728466', 240417002630007, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4042957' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'142589166', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728473', 240417002630006, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3878303' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'167614765', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728480', 240417002630013, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4621314' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'100848274', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728487', 240417002630009, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4164906' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'190499033', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728494', 240417002630004, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3620620' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'101472907', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728501', 240417002630012, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4482115' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'141099166', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728508', 240417002630019, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.5082767' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'188531025', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728515', 240417002630011, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4479531' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'153665524', 0, 1, 7, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728522', 240417002630005, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.3878301' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728529', 240417002630021, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.5985638' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728536', 240417002630010, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4358737' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728543', 240417002630014, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4791617' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728550', 240417002630018, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.5051146' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'100482873', 0, 0, 13, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728557', 240417002630015, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4809885' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'155382907', 0, 1, 7, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728564', 240417002630016, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.4831421' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'123317416', 1, 0, 4, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728571', 240417002630020, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.5590489' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'118241025', 0, 1, 7, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4728578', 240417002630017, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:04:23.5002544' AS DateTime2), N'2024-04-18', N'2024-04-18', CAST(10.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'c6672925-d3be-4dd7-8d41-9d002cb1abd8', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'142682873', 1, 0, 4, N'20240417170408144_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729040', 240417021330009, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4321851' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'102577416', 3, 1, 7, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729047', 240417021330001, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.3291152' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'107409274', 3, 0, 5, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729054', 240417021330002, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.3400712' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'123423873', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729061', 240417021330008, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4221735' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'167946657', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729068', 240417021330003, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.3582999' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'148877416', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729075', 240417021330010, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4322143' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'152891025', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729082', 240417021330005, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.3999914' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'183716524', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729089', 240417021330011, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4342409' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'142456657', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729096', 240417021330007, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4092737' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'144370266', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729103', 240417021330015, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4613770' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'193387416', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729110', 240417021330004, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.3688847' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'101202025', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729117', 240417021330006, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4510874' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'163923873', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729124', 240417021330018, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4730636' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729131', 240417021330012, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4321858' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 11, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729138', 240417021330014, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4602330' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729145', 240417021330020, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.5331265' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'0', 0, 0, 14, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729152', 240417021330013, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4360989' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'146040133', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729159', 240417021330017, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4650012' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'162280266', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729166', 240417021330021, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.5412593' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'129994765', 1, 0, 4, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729173', 240417021330016, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4620938' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'103719274', 0, 0, 13, N'20240417173515671_0')
GO
INSERT [dbo].[XieChengOrder] ([otaOrderId], [trade_no], [PLU], [locale], [createTime], [useStartDate], [useEndDate], [price], [quantity], [amount], [payedAmount], [status], [objectId], [userId], [name], [itemId], [cancelQuantity], [useQuantity], [orderStatus], [passengerIds]) VALUES (N'ctriptest-4729180', 240417021330019, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'zh-CN', CAST(N'2024-04-17T17:35:33.4822489' AS DateTime2), N'2024-04-22', N'2024-04-22', CAST(10.00 AS Decimal(18, 2)), 3, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, N'd25ea463-68c2-408c-9aac-ca61867c1f1c', 0, N'a5ca8766-10c5-42d4-a924-706f4dc6b593', N'104433873', 1, 0, 4, N'20240417173515671_0')
GO
SET IDENTITY_INSERT [dbo].[XieChengTicket] ON 
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1801, 1110, N'20240417170011697_0', N'169845657', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1802, 1111, N'20240417170011697_0', N'113389033', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1803, 1112, N'20240417170011697_0', N'129372873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1804, 1113, N'20240417170011697_0', N'102552907', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1805, 1114, N'20240417170011697_0', N'143945524', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1806, 1115, N'20240417170011697_0', N'107148274', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1807, 1116, N'20240417170011697_0', N'188862873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1808, 1117, N'20240417170011697_0', N'154062907', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1809, 1118, N'20240417170011697_0', N'190511025', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1810, 1119, N'20240417170011697_0', N'104538274', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1811, 1120, N'20240417170011697_0', N'168089033', 2)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1812, 1121, N'20240417170011697_0', N'100152907', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1813, 1122, N'20240417170011697_0', N'101928274', 2)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1814, 1123, N'20240417170011697_0', N'186369166', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1815, 1124, N'20240417170011697_0', N'103396416', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1816, 1125, N'20240417170011697_0', N'108825657', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1817, 1126, N'20240417170011697_0', N'146104765', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1818, 1127, N'20240417170408144_0', N'186065524', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1819, 1128, N'20240417170408144_0', N'144355657', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1820, 1129, N'20240417170408144_0', N'167614765', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1821, 1130, N'20240417170408144_0', N'142589166', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1822, 1131, N'20240417170408144_0', N'159821025', 2)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1823, 1132, N'20240417170408144_0', N'153665524', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1824, 1133, N'20240417170408144_0', N'100848274', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1825, 1134, N'20240417170408144_0', N'142682873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1826, 1135, N'20240417170408144_0', N'188531025', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1827, 1136, N'20240417170408144_0', N'149696416', 2)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1828, 1137, N'20240417170408144_0', N'190499033', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1829, 1138, N'20240417170408144_0', N'141099166', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1830, 1139, N'20240417170408144_0', N'123317416', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1831, 1140, N'20240417170408144_0', N'100482873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1832, 1141, N'20240417170408144_0', N'101472907', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1833, 1142, N'20240417170408144_0', N'155382907', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1834, 1143, N'20240417170408144_0', N'118241025', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1835, 1144, N'20240417173515671_0', N'107409274', 2)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1836, 1145, N'20240417173515671_0', N'101202025', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1837, 1146, N'20240417173515671_0', N'123423873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1838, 1147, N'20240417173515671_0', N'148877416', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1839, 1148, N'20240417173515671_0', N'167946657', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1840, 1149, N'20240417173515671_0', N'183716524', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1841, 1150, N'20240417173515671_0', N'163923873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1842, 1151, N'20240417173515671_0', N'162280266', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1843, 1152, N'20240417173515671_0', N'142456657', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1844, 1153, N'20240417173515671_0', N'104433873', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1845, 1154, N'20240417173515671_0', N'129994765', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1846, 1155, N'20240417173515671_0', N'144370266', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1847, 1156, N'20240417173515671_0', N'152891025', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1848, 1157, N'20240417173515671_0', N'193387416', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1849, 1158, N'20240417173515671_0', N'146040133', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1850, 1159, N'20240417173515671_0', N'103719274', 0)
GO
INSERT [dbo].[XieChengTicket] ([id], [ticketId], [OTAPassengerId], [itemId], [voucherStatus]) VALUES (1851, 1160, N'20240417173515671_0', N'102577416', 0)
GO
SET IDENTITY_INSERT [dbo].[XieChengTicket] OFF
GO
ALTER TABLE [dbo].[WechatBill] ADD  CONSTRAINT [DF__WechatBil__trade__0E391C95]  DEFAULT (CONVERT([bigint],(0))) FOR [tradeNo]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Exhibition_objectId] FOREIGN KEY([objectId])
REFERENCES [dbo].[Exhibition] ([id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Exhibition_objectId]
GO

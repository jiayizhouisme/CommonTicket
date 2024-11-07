USE [Common]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/11/7 17:32:23 ******/
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
/****** Object:  Table [dbo].[JobCluster]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCluster](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[UpdatedTime] [datetime2](7) NULL,
 CONSTRAINT [PK_JobCluster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobDetail]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[JobType] [nvarchar](max) NULL,
	[AssemblyName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Concurrent] [bit] NOT NULL,
	[IncludeAnnotations] [bit] NOT NULL,
	[Properties] [nvarchar](max) NULL,
	[UpdatedTime] [datetime2](7) NULL,
 CONSTRAINT [PK_JobDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTrigger]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTrigger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TriggerId] [nvarchar](max) NULL,
	[JobId] [nvarchar](max) NULL,
	[TriggerType] [nvarchar](max) NULL,
	[AssemblyName] [nvarchar](max) NULL,
	[Args] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bigint] NOT NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[LastRunTime] [datetime2](7) NULL,
	[NextRunTime] [datetime2](7) NULL,
	[NumberOfRuns] [bigint] NOT NULL,
	[MaxNumberOfRuns] [bigint] NOT NULL,
	[NumberOfErrors] [bigint] NOT NULL,
	[MaxNumberOfErrors] [bigint] NOT NULL,
	[NumRetries] [int] NOT NULL,
	[RetryTimeout] [int] NOT NULL,
	[StartNow] [bit] NOT NULL,
	[RunOnStart] [bit] NOT NULL,
	[ResetOnlyOnce] [bit] NOT NULL,
	[Result] [nvarchar](max) NULL,
	[ElapsedTime] [bigint] NOT NULL,
	[UpdatedTime] [datetime2](7) NULL,
 CONSTRAINT [PK_JobTrigger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Host] [nvarchar](256) NULL,
	[EmailAddress] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](32) NULL,
	[Schema] [nvarchar](32) NULL,
	[ConnectionString] [nvarchar](256) NULL,
	[CreatedTime] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestTable]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_TestTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WechatBillRefund]    Script Date: 2024/11/7 17:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatBillRefund](
	[refundId] [bigint] IDENTITY(1,1) NOT NULL,
	[aftersalesId] [nvarchar](20) NOT NULL,
	[money] [decimal](18, 2) NOT NULL,
	[userId] [int] NOT NULL,
	[sourceId] [nvarchar](20) NOT NULL,
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240120084533_v1.0.0', N'7.0.14')
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240329054303_v13.0', N'8.0.1')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240708072856_v1.0', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240708073843_v1.1', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240708075634_v1.2', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240710064203_v1.0.1', N'8.0.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240910060359_v1.0.1', N'8.0.8')
GO
INSERT [dbo].[JobCluster] ([Id], [Description], [Status], [UpdatedTime]) VALUES (1, NULL, 1, CAST(N'2024-11-07T16:53:19.9964893' AS DateTime2))
GO
INSERT [dbo].[JobCluster] ([Id], [Description], [Status], [UpdatedTime]) VALUES (2, NULL, 0, CAST(N'2024-03-18T14:42:50.2101075' AS DateTime2))
GO
INSERT [dbo].[Tenant] ([TenantId], [Name], [Host], [EmailAddress], [PhoneNumber], [Schema], [ConnectionString], [CreatedTime]) VALUES (N'fffafb88-f519-fff8-b364-33333bf3687f', N'shibabang', N'/shibabang', NULL, NULL, NULL, N'Data Source=localhost;Initial Catalog=CommonTicket2;user id=admin;password=Aa123456;TrustServerCertificate=true;', CAST(N'2020-01-01T00:00:00.0000000+08:00' AS DateTimeOffset))
GO
INSERT [dbo].[Tenant] ([TenantId], [Name], [Host], [EmailAddress], [PhoneNumber], [Schema], [ConnectionString], [CreatedTime]) VALUES (N'c5798cb6-16d6-0f42-eb56-59c695353bc0', N'anfeng', N'/anfeng', NULL, NULL, NULL, N'Data Source=localhost;Initial Catalog=CommonTicket2;user id=admin;password=Aa123456;TrustServerCertificate=true;Max Pool Size=64; Min Pool Size=5', CAST(N'2020-10-06T20:20:32.0000000+08:00' AS DateTimeOffset))
GO
INSERT [dbo].[Tenant] ([TenantId], [Name], [Host], [EmailAddress], [PhoneNumber], [Schema], [ConnectionString], [CreatedTime]) VALUES (N'383afb88-f519-fff8-b364-6d563bf3687f', N'/', N'/shagou1', NULL, NULL, NULL, N'Data Source=localhost;Initial Catalog=CommonTicket3;user id=admin;password=Aa123456;TrustServerCertificate=true;Max Pool Size=64; Min Pool Size=5', CAST(N'2020-10-06T20:19:07.0000000+08:00' AS DateTimeOffset))
GO
INSERT [dbo].[Tenant] ([TenantId], [Name], [Host], [EmailAddress], [PhoneNumber], [Schema], [ConnectionString], [CreatedTime]) VALUES (N'fffafb88-f519-fff8-b364-6d563bf3687f', N'test', N'/test', NULL, NULL, NULL, N'Data Source=localhost;Initial Catalog=CommonTicket3;user id=admin;password=Aa123456;TrustServerCertificate=true;', CAST(N'2020-01-01T00:00:00.0000000+08:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[TestTable] ON 
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (1, N'test', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (2, N'testtest', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (3, N'string', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (4, N'string', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (5, N'string', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (6, N'string', 1)
GO
INSERT [dbo].[TestTable] ([Id], [name], [IsDeleted]) VALUES (7, N'string', 1)
GO
SET IDENTITY_INSERT [dbo].[TestTable] OFF
GO
ALTER TABLE [dbo].[TestTable] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO

USE [ReservationBooks]
GO

/****** Object:  Table [dbo].[Members]    Script Date: 05.04.2025 13:41:31 ******/


CREATE TABLE [dbo].[Members](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [ReservationBooks]
GO

/****** Object:  Table [dbo].[BookInstanceStatuses]    Script Date: 05.04.2025 13:41:46 ******/

CREATE TABLE [dbo].[BookInstanceStatuses](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_BookInstanceStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [ReservationBooks]
GO

/****** Object:  Table [dbo].[BookInstances]    Script Date: 05.04.2025 13:42:06 ******/

CREATE TABLE [dbo].[BookInstances](
	[Id] [int] NOT NULL,
	[InventoryNumber] [nvarchar](50) NOT NULL,
	[BookId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_BookInstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BookInstances]  WITH CHECK ADD  CONSTRAINT [FK_BookInstances_BookInstanceStatuses_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[BookInstanceStatuses] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BookInstances] CHECK CONSTRAINT [FK_BookInstances_BookInstanceStatuses_StatusId]
GO



/****** Object:  Table [dbo].[Reservations]    Script Date: 05.04.2025 13:42:20 ******/


CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[ReservationDate] [datetime2](7) NOT NULL,
	[EndReservationDatePlan] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[BookInstanceId] [int] NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_BookInstances_BookInstanceId] FOREIGN KEY([BookInstanceId])
REFERENCES [dbo].[BookInstances] ([Id])
GO

ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_BookInstances_BookInstanceId]
GO

ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Members_MemberId]
GO


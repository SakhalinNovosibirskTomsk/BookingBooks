USE [Catalog]
GO

/****** Object:  Table [dbo].[Authors]    Script Date: 05.04.2025 13:39:26 ******/

CREATE TABLE [dbo].[Authors](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Books]    Script Date: 05.04.2025 13:39:53 ******/


CREATE TABLE [dbo].[Books](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ISBN] [nvarchar](20) NOT NULL,
	[PublisherId] [int] NULL,
	[PublishDate] [date] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([Id])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO

/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 05.04.2025 13:39:53 ******/

CREATE TABLE [dbo].[BooksAuthors](
	[BookId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO

ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Authors]
GO

ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO

ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Books]
GO

/****** Object:  Table [dbo].[Publishers]    Script Date: 05.04.2025 13:40:13 ******/

CREATE TABLE [dbo].[Publishers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[BookInstance]   Script Date: 05.04.2025 13:40:13 ******/
CREATE TABLE [dbo].[BookInstances](
	[Id] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[InventoryNumber] [nvarchar](32) NOT NULL,
	[IsReserved] [bit] NULL,
	[IsCheckedOut] [bit] NULL,
	[IsWrittenOff] [bit] NULL,
 CONSTRAINT [PK_BookInstances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BookInstances]  WITH CHECK ADD  CONSTRAINT [FK_BookInstances_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO

ALTER TABLE [dbo].[BookInstances] CHECK CONSTRAINT [FK_BookInstances_Books]
GO



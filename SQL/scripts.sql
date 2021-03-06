USE [master]
GO
/****** Object:  Database [MtaELearning]    Script Date: 10/14/2019 10:40:09 AM ******/
CREATE DATABASE [MtaELearning]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MtaELearning', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\MtaELearning.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MtaELearning_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\MtaELearning_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MtaELearning] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MtaELearning].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MtaELearning] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MtaELearning] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MtaELearning] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MtaELearning] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MtaELearning] SET ARITHABORT OFF 
GO
ALTER DATABASE [MtaELearning] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MtaELearning] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MtaELearning] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MtaELearning] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MtaELearning] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MtaELearning] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MtaELearning] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MtaELearning] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MtaELearning] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MtaELearning] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MtaELearning] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MtaELearning] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MtaELearning] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MtaELearning] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MtaELearning] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MtaELearning] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MtaELearning] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MtaELearning] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MtaELearning] SET  MULTI_USER 
GO
ALTER DATABASE [MtaELearning] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MtaELearning] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MtaELearning] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MtaELearning] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MtaELearning] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MtaELearning]
GO
/****** Object:  Table [dbo].[Anwser]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Anwser](
	[id] [int] NOT NULL,
	[content] [nvarchar](max) NULL,
	[type] [char](1) NULL,
	[question_id] [int] NULL,
 CONSTRAINT [PK_Anwser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chapter]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapter](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[course_id] [int] NULL,
	[index_num] [int] NULL,
 CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[id] [int] NOT NULL,
	[comment_parrent] [int] NULL,
	[content] [nvarchar](max) NULL,
	[time] [datetime] NULL,
	[status] [varchar](10) NULL,
	[user_id] [int] NULL,
	[lesson_id] [int] NULL,
	[index_num] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[price] [float] NULL,
	[image_url] [nvarchar](255) NULL,
	[is_visiable] [bit] NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NULL,
	[description] [nvarchar](max) NULL,
	[video_url] [nvarchar](255) NULL,
	[chapter_id] [int] NULL,
	[video_time] [float] NULL,
 CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Question]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[id] [int] NOT NULL,
	[scores] [int] NULL,
	[test_id] [int] NULL,
	[correct_answer] [char](1) NULL,
	[index_num] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[id] [int] NOT NULL,
	[content] [nvarchar](255) NULL,
	[time] [datetime] NULL,
	[stars] [int] NULL,
	[is_visible] [bit] NULL,
	[course_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Test]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[id] [int] NOT NULL,
	[name] [nvarchar](255) NULL,
	[time] [float] NULL,
	[chapter_id] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[date] [date] NULL,
	[time] [time](7) NULL,
	[total_price] [float] NULL,
	[paid] [float] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[user_name] [nchar](20) NULL,
	[email] [nchar](30) NULL,
	[phone_number] [nchar](20) NULL,
	[address] [nvarchar](50) NULL,
	[gender] [bit] NULL,
	[birth_day] [date] NULL,
	[user_role] [nchar](10) NULL,
	[scores] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Course]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Course](
	[id] [int] NOT NULL,
	[user_id] [int] NULL,
	[course_id] [int] NULL,
	[isowner] [bit] NULL,
	[datetime] [datetime] NULL,
 CONSTRAINT [PK_User_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Lesson]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Lesson](
	[id] [int] NOT NULL,
	[user_id] [int] NULL,
	[lesson_id] [int] NULL,
	[is_complete] [bit] NULL,
	[time] [int] NULL,
 CONSTRAINT [PK_User_Lesson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Test]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Test](
	[id] [int] NOT NULL,
	[user_id] [int] NULL,
	[test_id] [int] NULL,
 CONSTRAINT [PK_User_Test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Video]    Script Date: 10/14/2019 10:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[id] [nvarchar](255) NOT NULL,
	[name] [nvarchar](50) NULL,
	[url] [nvarchar](255) NULL,
	[time] [float] NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Anwser]  WITH CHECK ADD  CONSTRAINT [FK_Anwser_Question] FOREIGN KEY([question_id])
REFERENCES [dbo].[Question] ([id])
GO
ALTER TABLE [dbo].[Anwser] CHECK CONSTRAINT [FK_Anwser_Question]
GO
ALTER TABLE [dbo].[Chapter]  WITH CHECK ADD  CONSTRAINT [FK_Chapter_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Chapter] CHECK CONSTRAINT [FK_Chapter_Course]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Comment] FOREIGN KEY([comment_parrent])
REFERENCES [dbo].[Comment] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Comment]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Lesson] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Lesson]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Category] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Category]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Chapter] FOREIGN KEY([chapter_id])
REFERENCES [dbo].[Chapter] ([id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Chapter]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Video] FOREIGN KEY([video_url])
REFERENCES [dbo].[Video] ([id])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK_Lesson_Video]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Test] FOREIGN KEY([test_id])
REFERENCES [dbo].[Test] ([id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Test]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Course]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_User]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Chapter] FOREIGN KEY([chapter_id])
REFERENCES [dbo].[Chapter] ([id])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Chapter]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_User]
GO
ALTER TABLE [dbo].[User_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Course_Course] FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[User_Course] CHECK CONSTRAINT [FK_User_Course_Course]
GO
ALTER TABLE [dbo].[User_Course]  WITH CHECK ADD  CONSTRAINT [FK_User_Course_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[User_Course] CHECK CONSTRAINT [FK_User_Course_User]
GO
ALTER TABLE [dbo].[User_Lesson]  WITH CHECK ADD  CONSTRAINT [FK_User_Lesson_Lesson] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[Lesson] ([id])
GO
ALTER TABLE [dbo].[User_Lesson] CHECK CONSTRAINT [FK_User_Lesson_Lesson]
GO
ALTER TABLE [dbo].[User_Lesson]  WITH CHECK ADD  CONSTRAINT [FK_User_Lesson_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[User_Lesson] CHECK CONSTRAINT [FK_User_Lesson_User]
GO
ALTER TABLE [dbo].[User_Test]  WITH CHECK ADD  CONSTRAINT [FK_User_Test_Test] FOREIGN KEY([test_id])
REFERENCES [dbo].[Test] ([id])
GO
ALTER TABLE [dbo].[User_Test] CHECK CONSTRAINT [FK_User_Test_Test]
GO
ALTER TABLE [dbo].[User_Test]  WITH CHECK ADD  CONSTRAINT [FK_User_Test_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[User_Test] CHECK CONSTRAINT [FK_User_Test_User]
GO
USE [master]
GO
ALTER DATABASE [MtaELearning] SET  READ_WRITE 
GO

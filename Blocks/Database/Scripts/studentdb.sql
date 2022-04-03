

USE [master]
GO
DROP DATABASE IF EXISTS [StudentDB]
GO
CREATE DATABASE [StudentDB]
GO
USE [StudentDB]
CREATE TABLE [dbo].[Course](
	[CourseID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Credits] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Enrollments]    Script Date: 4/2/2022 11:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [uniqueidentifier] NOT NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Grade] [int] NULL,
	[CourseID1] [uniqueidentifier] NULL,
	[StudentID1] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/2/2022 11:24:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [uniqueidentifier] NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[FirstMidName] [nvarchar](max) NOT NULL,
	[EnrollmentDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_CourseID1]    Script Date: 4/2/2022 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enrollment_CourseID1] ON [dbo].[Enrollment]
(
	[CourseID1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Enrollments_StudentID1]    Script Date: 4/2/2022 11:24:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Enrollment_StudentID1] ON [dbo].[Enrollment]
(
	[StudentID1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Course_CourseID1] FOREIGN KEY([CourseID1])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Course_CourseID1]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_Enrollment_Student_StudentID1] FOREIGN KEY([StudentID1])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_Enrollment_Student_StudentID1]
GO
USE [master]
GO
ALTER DATABASE [StudentDB] SET  READ_WRITE 
GO

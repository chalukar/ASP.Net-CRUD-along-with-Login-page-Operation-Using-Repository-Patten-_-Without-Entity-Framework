CREATE TABLE [dbo].[Role](
	[ID] [int] Primary Key IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	)

CREATE TABLE [dbo].[User](
	[Id] [Int] Primary Key IDENTITY(1,1),
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[RoleId] [Int] FOREIGN KEY REFERENCES [Role](ID),
	)

CREATE TABLE [dbo].[City](
	[Id] [Int] Primary Key IDENTITY(1,1),
	[CityName] [nvarchar](100) NOT NULL,
	)

CREATE TABLE [dbo].[Employee](
	[Id] [nvarchar](20) NOT NULL,
	[UserId] [Int] FOREIGN KEY REFERENCES [User](Id),
	[CityId] [Int] FOREIGN KEY REFERENCES [City](Id),
	[Age] [int] NOT NULL,
	[Sex] [char](1) NOT NULL,
	[JoinedDate] [datetime] NOT NULL,
	[ContactNo] [nvarchar](10) NOT NULL,
	)


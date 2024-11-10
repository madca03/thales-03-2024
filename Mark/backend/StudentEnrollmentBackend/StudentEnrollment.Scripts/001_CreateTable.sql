CREATE TABLE [dbo].[Student] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [BirthDate] datetime2(7) NOT NULL,
    [Phone] nvarchar(10) NULL,
    [Email] nvarchar(50) NULL,
    [Gender] [nvarchar](10) NOT NULL,
    [Address] [nvarchar](100) NULL,
    CONSTRAINT PK_Student PRIMARY KEY ([Id])
    );

CREATE TABLE [dbo].[Course] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [StartDate] datetime2(7) NOT NULL,
    [EndDate] datetime2(7) NOT NULL,
    [Fees] float NOT NULL,
    [LocationAddress] nvarchar(100) NOT NULL,
    [ContactPerson] nvarchar(100) NOT NULL,
    CONSTRAINT PK_Course PRIMARY KEY ([Id])
    );

CREATE INDEX IX_Course_Name ON [dbo].[Course] ([Name]);
CREATE INDEX IX_Course_StartDate ON [dbo].[Course] ([StartDate]);
CREATE INDEX IX_Course_EndDate ON [dbo].[Course]([EndDate]);

CREATE TABLE [dbo].[Subject] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [CourseId] int NOT NULL,
    CONSTRAINT PK_Subject PRIMARY KEY ([Id]),
    CONSTRAINT FK_Subject_Course FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course]([Id])
    )

CREATE TABLE [dbo].[Enrollment] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [StudentId] int NOT NULL,
    [CourseId] int NOT NULL,
    [EnrollmentDate] datetime2(7) NOT NULL,
    [Status] nvarchar(50) NOT NULL,
    [Comments] nvarchar(100) NULL,
    CONSTRAINT PK_Enrollment PRIMARY KEY ([Id]),
    CONSTRAINT UQ_Enrollment_StudentId_CourseId UNIQUE ([StudentId], [CourseId])
    )

CREATE INDEX IX_Enrollment_EnrollmentDate ON [dbo].[Enrollment]([EnrollmentDate])
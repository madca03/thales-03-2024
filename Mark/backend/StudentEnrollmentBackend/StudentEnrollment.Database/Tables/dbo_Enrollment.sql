CREATE TABLE [dbo].[Enrollment] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [StudentId] int NOT NULL,
    [CourseId] int NOT NULL,
    [EnrollmentDate] datetime2(7) NOT NULL,
    [Status] nvarchar(50) NOT NULL,
    [Comments] nvarchar(100) NULL,
    CONSTRAINT PK_Enrollment PRIMARY KEY ([Id]),
    CONSTRAINT UQ_Enrollment_StudentId_CourseId UNIQUE ([StudentId], [CourseId])
);

CREATE INDEX IX_Enrollment_EnrollmentDate ON [dbo].[Enrollment]([EnrollmentDate]);
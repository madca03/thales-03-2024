CREATE TABLE [dbo].[Subject] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [CourseId] int NOT NULL,
    CONSTRAINT PK_Subject PRIMARY KEY ([Id]),
    CONSTRAINT FK_Subject_Course FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course]([Id])
);

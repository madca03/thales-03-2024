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


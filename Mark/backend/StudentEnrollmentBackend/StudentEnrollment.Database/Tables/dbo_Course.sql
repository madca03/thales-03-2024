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

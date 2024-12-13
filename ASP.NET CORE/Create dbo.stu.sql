DROP TABLE [dbo].[stu];
GO

CREATE TABLE [dbo].[stu] (
    [Id]   INT         NOT NULL,
    [Name] VARCHAR (50) NULL
);
GO

INSERT INTO STU (ID, Name)  
VALUES (1, 'John Doe');

CREATE TABLE [dbo].[Technologies] (
    [TechnologyId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Technologies] PRIMARY KEY CLUSTERED ([TechnologyId] ASC)
);


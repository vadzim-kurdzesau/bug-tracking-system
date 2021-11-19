CREATE TABLE [dbo].[bug_types] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [type]        NVARCHAR (20)  NOT NULL,
    [description] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


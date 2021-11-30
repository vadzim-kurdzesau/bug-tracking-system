CREATE TABLE [dbo].[bug_types] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [type]        NVARCHAR (20)  NULL,
    [description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.bug_types] PRIMARY KEY CLUSTERED ([id] ASC)
);


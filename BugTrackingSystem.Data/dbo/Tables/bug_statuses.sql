CREATE TABLE [dbo].[bug_statuses] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [status]      NVARCHAR (20)  NOT NULL,
    [description] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_bug_statuses] PRIMARY KEY CLUSTERED ([id] ASC)
);


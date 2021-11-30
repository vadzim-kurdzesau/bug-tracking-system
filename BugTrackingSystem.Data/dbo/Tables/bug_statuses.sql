CREATE TABLE [dbo].[bug_statuses] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [status]      NVARCHAR (20)  NULL,
    [description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.bug_statuses] PRIMARY KEY CLUSTERED ([id] ASC)
);


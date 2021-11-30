CREATE TABLE [dbo].[projects] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (30) NULL,
    [start_date] DATETIME     NOT NULL,
    CONSTRAINT [PK_dbo.projects] PRIMARY KEY CLUSTERED ([id] ASC)
);


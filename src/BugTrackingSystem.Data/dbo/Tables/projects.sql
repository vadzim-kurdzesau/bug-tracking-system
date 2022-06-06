CREATE TABLE [dbo].[projects] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (30)  NOT NULL,
    [start_date] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED ([id] ASC)
);


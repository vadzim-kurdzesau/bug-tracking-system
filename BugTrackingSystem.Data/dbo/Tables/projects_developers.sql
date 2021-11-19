CREATE TABLE [dbo].[projects_developers] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [project_id]   INT NULL,
    [developer_id] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_developers_in_projects_to_developers] FOREIGN KEY ([developer_id]) REFERENCES [dbo].[developers] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_developers_in_projects_to_projects] FOREIGN KEY ([project_id]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE,
    CONSTRAINT [UQ_developers_in_projects] UNIQUE NONCLUSTERED ([project_id] ASC, [developer_id] ASC)
);


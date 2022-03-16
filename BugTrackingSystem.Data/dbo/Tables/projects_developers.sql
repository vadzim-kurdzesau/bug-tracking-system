CREATE TABLE [dbo].[projects_developers] (
    [DevelopersId] INT NOT NULL,
    [ProjectsId]   INT NOT NULL,
    CONSTRAINT [PK_projects_developers] PRIMARY KEY CLUSTERED ([DevelopersId] ASC, [ProjectsId] ASC),
    CONSTRAINT [FK_projects_developers_developers_DevelopersId] FOREIGN KEY ([DevelopersId]) REFERENCES [dbo].[developers] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_projects_developers_projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_projects_developers_ProjectsId]
    ON [dbo].[projects_developers]([ProjectsId] ASC);


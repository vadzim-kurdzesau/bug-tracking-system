CREATE TABLE [dbo].[ProjectDevelopers] (
    [Project_Id]   INT NOT NULL,
    [Developer_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ProjectDevelopers] PRIMARY KEY CLUSTERED ([Project_Id] ASC, [Developer_Id] ASC),
    CONSTRAINT [FK_dbo.ProjectDevelopers_dbo.developers_Developer_Id] FOREIGN KEY ([Developer_Id]) REFERENCES [dbo].[developers] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ProjectDevelopers_dbo.projects_Project_Id] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Project_Id]
    ON [dbo].[ProjectDevelopers]([Project_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Developer_Id]
    ON [dbo].[ProjectDevelopers]([Developer_Id] ASC);


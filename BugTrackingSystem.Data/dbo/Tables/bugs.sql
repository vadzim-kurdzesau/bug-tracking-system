CREATE TABLE [dbo].[bugs] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [description]   NVARCHAR (200) NOT NULL,
    [update_date]   DATETIME2 (7)  NOT NULL,
    [bug_type_id]   INT            NOT NULL,
    [bug_status_id] INT            NOT NULL,
    [project_id]    INT            NOT NULL,
    [developer_id]  INT            NULL,
    CONSTRAINT [PK_bugs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_bugs_bug_statuses_bug_status_id] FOREIGN KEY ([bug_status_id]) REFERENCES [dbo].[bug_statuses] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_bugs_bug_types_bug_type_id] FOREIGN KEY ([bug_type_id]) REFERENCES [dbo].[bug_types] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_bugs_developers_developer_id] FOREIGN KEY ([developer_id]) REFERENCES [dbo].[developers] ([id]),
    CONSTRAINT [FK_bugs_projects_project_id] FOREIGN KEY ([project_id]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_bug_status_id]
    ON [dbo].[bugs]([bug_status_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_bug_type_id]
    ON [dbo].[bugs]([bug_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_developer_id]
    ON [dbo].[bugs]([developer_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_project_id]
    ON [dbo].[bugs]([project_id] ASC);


GO
CREATE TRIGGER TR_bugs_UPDATE
                                               ON dbo.bugs
                                            AFTER INSERT, UPDATE
                                               AS
                                           INSERT bugs_audit
                                                    (bug_id, description, update_date, bug_type_id, bug_status_id, project_id, developer_id)
                                           SELECT id, description, update_date, bug_type_id, bug_status_id, project_id, developer_id
                                             FROM inserted; 

CREATE TABLE [dbo].[bugs_audit] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [bug_id]            INT            NOT NULL,
    [description]       NVARCHAR (200) NOT NULL,
    [update_date]       DATETIME2 (7)  NOT NULL,
    [bug_type_id]       INT            NOT NULL,
    [bug_status_id]     INT            NOT NULL,
    [project_id]        INT            NOT NULL,
    [developer_id]      INT            NULL,
    [developer_message] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_bugs_audit] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_bugs_audit_bug_statuses_bug_status_id] FOREIGN KEY ([bug_status_id]) REFERENCES [dbo].[bug_statuses] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_bugs_audit_bug_types_bug_type_id] FOREIGN KEY ([bug_type_id]) REFERENCES [dbo].[bug_types] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_bugs_audit_developers_developer_id] FOREIGN KEY ([developer_id]) REFERENCES [dbo].[developers] ([id]),
    CONSTRAINT [FK_bugs_audit_projects_project_id] FOREIGN KEY ([project_id]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_audit_bug_status_id]
    ON [dbo].[bugs_audit]([bug_status_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_audit_bug_type_id]
    ON [dbo].[bugs_audit]([bug_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_audit_developer_id]
    ON [dbo].[bugs_audit]([developer_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_bugs_audit_project_id]
    ON [dbo].[bugs_audit]([project_id] ASC);


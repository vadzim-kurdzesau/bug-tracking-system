CREATE TABLE [dbo].[bugs_audit] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [bug_id]            INT            NOT NULL,
    [bug_description]   NVARCHAR (200) NOT NULL,
    [update_date]       DATE           NOT NULL,
    [bug_type_id]       INT            NOT NULL,
    [bug_status_id]     INT            NOT NULL,
    [project_id]        INT            NOT NULL,
    [developer_id]      INT            NULL,
    [developer_message] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_bugs_audit_to_bug_statuses] FOREIGN KEY ([bug_status_id]) REFERENCES [dbo].[bug_statuses] ([id]),
    CONSTRAINT [FK_bugs_audit_to_bug_types] FOREIGN KEY ([bug_type_id]) REFERENCES [dbo].[bug_types] ([id]),
    CONSTRAINT [FK_bugs_audit_to_developers] FOREIGN KEY ([developer_id]) REFERENCES [dbo].[developers] ([id]),
    CONSTRAINT [FK_bugs_audit_to_projects] FOREIGN KEY ([project_id]) REFERENCES [dbo].[projects] ([id])
);


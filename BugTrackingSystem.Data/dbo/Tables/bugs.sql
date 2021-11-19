CREATE TABLE [dbo].[bugs] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [description]   NVARCHAR (200) NOT NULL,
    [update_date]   DATE           NOT NULL,
    [bug_type_id]   INT            NOT NULL,
    [bug_status_id] INT            NOT NULL,
    [project_id]    INT            NOT NULL,
    [developer_id]  INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_bugs_to_bug_statuses] FOREIGN KEY ([bug_status_id]) REFERENCES [dbo].[bug_statuses] ([id]),
    CONSTRAINT [FK_bugs_to_bug_types] FOREIGN KEY ([bug_type_id]) REFERENCES [dbo].[bug_types] ([id]),
    CONSTRAINT [FK_bugs_to_developers] FOREIGN KEY ([developer_id]) REFERENCES [dbo].[developers] ([id]) ON DELETE SET NULL,
    CONSTRAINT [FK_bugs_to_projects] FOREIGN KEY ([project_id]) REFERENCES [dbo].[projects] ([id]) ON DELETE CASCADE
);


GO
CREATE TRIGGER TR_bugs_UPDATE
	    ON dbo.bugs
	 AFTER INSERT, UPDATE
AS
	INSERT bugs_audit
		   (bug_id, bug_description, update_date, bug_type_id, bug_status_id, project_id, developer_id)
	SELECT	id,		description,	 update_date, bug_type_id, bug_status_id, project_id, developer_id
	  FROM	inserted;
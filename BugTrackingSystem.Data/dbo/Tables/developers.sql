CREATE TABLE [dbo].[developers] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [first_name] NVARCHAR (20) NULL,
    [last_name]  NVARCHAR (30) NULL,
    [email]      VARCHAR (320) NULL,
    [phone]      VARCHAR (20)  NULL,
    CONSTRAINT [PK_dbo.developers] PRIMARY KEY CLUSTERED ([id] ASC)
);


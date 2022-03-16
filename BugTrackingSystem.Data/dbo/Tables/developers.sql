CREATE TABLE [dbo].[developers] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [first_name] NVARCHAR (20)  NOT NULL,
    [last_name]  NVARCHAR (30)  NOT NULL,
    [email]      NVARCHAR (320) NOT NULL,
    [phone]      NVARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_developers] PRIMARY KEY CLUSTERED ([id] ASC)
);


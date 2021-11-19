CREATE TABLE [dbo].[developers] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [first_name] NVARCHAR (20) NOT NULL,
    [last_name]  NVARCHAR (30) NOT NULL,
    [email]      VARCHAR (320) NOT NULL,
    [phone]      VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC, [phone] ASC)
);


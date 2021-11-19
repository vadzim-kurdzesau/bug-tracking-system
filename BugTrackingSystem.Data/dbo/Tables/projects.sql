CREATE TABLE [dbo].[projects] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (30) NOT NULL,
    [start_date] DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);


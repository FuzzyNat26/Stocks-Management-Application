CREATE TABLE [dbo].[Users] (
    [username]   VARCHAR (50) NOT NULL,
    [first_name] VARCHAR (50) NULL,
    [last_name]  VARCHAR (50) NULL,
    [password]   NCHAR (10)   NULL,
    [email]      VARCHAR (50) NULL,
    [phone]      VARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([username] ASC)
);
CREATE TABLE [Reporting].[User] (
    [UserId]     INT           IDENTITY (1, 1) NOT NULL,
    [UserName]   NVARCHAR (50) NOT NULL,
    [CreateDate] DATETIME      NOT NULL,
    [UpdateDate] DATETIME      NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


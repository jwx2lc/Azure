CREATE TABLE [Reporting].[Role] (
    [RoleId]     INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]   NVARCHAR (50) NOT NULL,
    [CreateDate] DATETIME      NOT NULL,
    [UpdateDate] DATETIME      NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


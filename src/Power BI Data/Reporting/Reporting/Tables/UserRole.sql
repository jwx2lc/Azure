CREATE TABLE [Reporting].[UserRole] (
    [UserRoleId] INT      IDENTITY (1, 1) NOT NULL,
    [RoleId]     INT      NOT NULL,
    [UserId]     INT      NOT NULL,
    [CreateDate] DATETIME NOT NULL,
    [UpdateDate] DATETIME NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [Reporting].[Role] ([RoleId]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [Reporting].[User] ([UserId])
);


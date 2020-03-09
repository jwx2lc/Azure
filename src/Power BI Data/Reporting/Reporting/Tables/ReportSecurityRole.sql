CREATE TABLE [Reporting].[ReportSecurityRole] (
    [ReportRoleId]     INT           IDENTITY (1, 1) NOT NULL,
    [ReportId]         INT           NOT NULL,
    [SecurityRoleName] NVARCHAR (50) NOT NULL,
    [CreateDate]       DATETIME      NOT NULL,
    [UpdateDate]       DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([ReportRoleId] ASC),
    CONSTRAINT [FK_ReportRole_Report] FOREIGN KEY ([ReportId]) REFERENCES [Reporting].[Report] ([ReportId])
);


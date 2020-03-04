CREATE TABLE [Reporting].[ReportRole]
(
	[ReportRoleId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ReportId] INT NOT NULL, 
    [RoleName] NVARCHAR(50) NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [UpdateDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_ReportRole_Report] FOREIGN KEY ([ReportId]) REFERENCES [Reporting].[Report]([ReportId])
)

CREATE TABLE [Reporting].[Report] (
    [ReportId]        INT              IDENTITY (1, 1) NOT NULL,
    [DisplayName]     NVARCHAR (50)    NOT NULL,
    [ReportName]      NVARCHAR (50)    NOT NULL,
    [PowerBIReportId] UNIQUEIDENTIFIER NOT NULL,
    [PowerBIGroupId]  UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]      DATETIME         NOT NULL,
    [UpdateDate]      DATETIME         NOT NULL,
    CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([ReportId] ASC)
);




CREATE TABLE [Reporting].[ReportVisual] (
    [ReportVisualId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [ReportId]       INT           NOT NULL,
    [PageName]       NVARCHAR (50) NOT NULL,
    [VisualName]     NVARCHAR (50) NOT NULL,
    [SortOrder]      INT           NOT NULL,
    [PageLocationX]  INT           NULL,
    [PageLocationY]  INT           NULL,
    [CreateDate]     DATETIME      NOT NULL,
    [UpdateDate]     DATETIME      NOT NULL,
    CONSTRAINT [FK_ReportVisual_Report] FOREIGN KEY ([ReportId]) REFERENCES [Reporting].[Report] ([ReportId])
);


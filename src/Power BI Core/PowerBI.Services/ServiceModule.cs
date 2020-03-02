using Autofac;
using PowerBI.Services.Power_BI;
using PowerBI.Services.Power_BI.Interfaces;
using PowerBI.Services.Reporting;
using PowerBI.Services.Reporting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Services
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PowerBIEmbedService>().As<IPowerBIEmbedService>();

            builder.RegisterType<ReportingService>().As<IReportingService>();
        }
    }
}

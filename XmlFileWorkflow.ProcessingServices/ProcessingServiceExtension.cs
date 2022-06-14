using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;
using XmlFileWorkflow.ProcessingServices.Processing;

namespace XmlFileWorkflow.ProcessingServices;
public static class ProcessingServiceExtension
{
    public static IServiceCollection AddProcessingService(this IServiceCollection services, HostBuilderContext hostBuilder)
    {
        services.AddTransient<IProcessingService, SequentialProcessingService>();
        services.AddSingleton<IProcessingReport, ProcessingReport>();
        return services;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Models.Options;
using XmlFileWorkflow.InputServices;
using XmlFileWorkflow.ProcessingServices;

namespace XmlFileWorkflow.Cli;

internal class HostBuilderFactory
{
    internal static IHostBuilder GetWithDefaults(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureAppConfiguration(ConfigureAppConfiguration)
            .ConfigureLogging(ConfigureLogging)
            .ConfigureServices(ConfigureServices);
    }

    private static void ConfigureAppConfiguration(HostBuilderContext hostBuilder, IConfigurationBuilder configBuilder)
    {
        // app config services for all workers
    }

    private static void ConfigureLogging(HostBuilderContext hostBuilder, ILoggingBuilder logBuilder)
    {
        // logging services for all workers
    }

    private static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
    {
        // default services for all workers
    }
}

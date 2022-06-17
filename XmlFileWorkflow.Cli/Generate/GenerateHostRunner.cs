using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Models.Options;

namespace XmlFileWorkflow.Cli.Generate;

internal class GenerateHostRunner
{
    internal static async Task RunAsync(string[] args, GenerateArgs options)
    {
        var hostBuilder = HostBuilderFactory.GetWithDefaults(args);

        hostBuilder.ConfigureServices((hostBuilder, services) => ConfigureServices(hostBuilder, services, options));
        var host = hostBuilder.Build();
        await host.RunAsync();
    }

    private static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services, GenerateArgs options)
    {
        // Options pattern for appsettings with cmd line override
        services.AddOptions<GenerateOptions>()
            .Bind(hostBuilder.Configuration.GetSection(nameof(GenerateOptions)))
            .Configure(o =>
            {
                // override appsettings with cmd line args here, if used.
            });

        services.AddHostedService<GenerateWorker>();
        //.AddSingleton<IMergeOptions>(options)
        //.AddMergeServices();
    }
}

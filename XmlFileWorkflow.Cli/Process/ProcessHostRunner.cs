using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Models.Options;
using XmlFileWorkflow.InputServices;
using XmlFileWorkflow.ProcessingServices;

namespace XmlFileWorkflow.Cli.Process;
internal class ProcessHostRunner
{
    internal static async Task RunAsync(string[] args, ProcessArgs options)
    {
        var hostBuilder = HostBuilderFactory.GetWithDefaults(args);

        hostBuilder.ConfigureServices((hostBuilder, services) => ConfigureServices(hostBuilder, services, options));

        var host = hostBuilder.Build();
        await host.RunAsync();
    }

    private static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services, ProcessArgs processArgs)
    {
        // Options pattern for appsettings with cmd line override
        services.AddOptions<FileSystemOptions>()
            .Bind(hostBuilder.Configuration.GetSection(nameof(FileSystemOptions)))
            .Configure(o =>
            {
                // use arg folder if provided, otherwise use appsettings - then prepend the MyDocs folder.
                o.Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), processArgs.Folder ?? o.Folder);
                o.Extension = processArgs.Extension ?? o.Extension;
                o.Rootname = processArgs.Rootname ?? o.Rootname;
            });

        services.AddOptions<ProcessOptions>()
            .Bind(hostBuilder.Configuration.GetSection(nameof(ProcessOptions)))
            .Configure(o =>
            {
                // Arg overrides appsettings option
                o.Async = processArgs.Async;
            });

        services.AddInputService();
        services.AddProcessingService();
        services.AddHostedService<ProcessWorker>();
        //.AddSingleton<IMergeOptions>(options)
        //.AddMergeServices();
    }
}

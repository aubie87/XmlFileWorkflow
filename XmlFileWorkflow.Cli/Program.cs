using XmlFileWorkflow.Cli;
using XmlFileWorkflow.InputServices;
using XmlFileWorkflow.ProcessingServices;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging((hostBuilder, logBuilder) => ConfigureLogging(hostBuilder, logBuilder))
    .ConfigureServices((hostBuilder,services) => ConfigureServices(hostBuilder, services))
    .Build();

await host.RunAsync();

void ConfigureLogging(HostBuilderContext hostBuilder, ILoggingBuilder logBuilder)
{
    // nothing here yet.
}

void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
{
    services.AddInputService(hostBuilder);
    services.AddProcessingService(hostBuilder);
    services.AddHostedService<Worker>();
}


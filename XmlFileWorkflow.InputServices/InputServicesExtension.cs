using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;
using XmlFileWorkflow.InputServices.ExistingFiles;

namespace XmlFileWorkflow.InputServices;
public static class InputServicesExtension
{
    public static IServiceCollection AddInputService(this IServiceCollection services, HostBuilderContext hostBuilder)
    {
        services.AddTransient<IInputService, ExistingFilesService>();
        return services;
    }
}

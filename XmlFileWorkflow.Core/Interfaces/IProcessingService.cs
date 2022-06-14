using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFileWorkflow.Core.Interfaces;
public interface IProcessingService
{
    IProcessingReport ProcessFiles(IEnumerable<FileInfo> files);
    Task<IProcessingReport> ProcessFilesAsync(IEnumerable<FileInfo> files, CancellationToken stoppingToken);
}

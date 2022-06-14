using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;

namespace XmlFileWorkflow.ProcessingServices.Processing;
public class SequentialProcessingService : IProcessingService
{
    private readonly ILogger<SequentialProcessingService> _logger;
    private readonly IProcessingReport _processingReport;

    public SequentialProcessingService(ILogger<SequentialProcessingService> logger, IProcessingReport processingReport)
    {
        _logger = logger;
        _processingReport = processingReport;
    }

    public IProcessingReport ProcessFiles(IEnumerable<FileInfo> files)
    {
        _logger.LogInformation("Processing {count} files.", files.Count());
        foreach (FileInfo file in files)
        {
            _logger.LogInformation("  {file}", file.Name);
        }
        _processingReport.Finish();
        return _processingReport;
    }

    public Task<IProcessingReport> ProcessFilesAsync(IEnumerable<FileInfo> files, CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlFileWorkflow.Core.Interfaces;
using XmlFileWorkflow.Core.Models.Xml;

namespace XmlFileWorkflow.ProcessingServices.Processing;

/// <summary>
/// Process each file sequentially.
/// Easily exchange different XML parsers to determine speed and memory issues.
/// Async/await may benefit with interleaving XML parsing with DB saves (IO calls).
/// </summary>
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
            TestLoadXml(file);
        }
        _processingReport.Finish();
        return _processingReport;
    }

    private void TestLoadXml(FileInfo file)
    {
        using var stream = file.OpenRead();
        var serializer = new XmlSerializer(typeof(StatementRoot));
        if (serializer.Deserialize(stream) is StatementRoot xml)
        {
            _logger.LogInformation("Found {count} statements in file.", xml.Statements.Count);
        }
        stream.Close();
    }

    public Task<IProcessingReport> ProcessFilesAsync(IEnumerable<FileInfo> files, CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}

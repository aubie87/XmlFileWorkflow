using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;

namespace XmlFileWorkflow.InputServices.ExistingFiles;
public class ExistingFilesService : IInputService
{
    private readonly ILogger<ExistingFilesService> _logger;

    public ExistingFilesService(ILogger<ExistingFilesService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<FileInfo> FileList()
    {
        string processingFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FileProcessingPerfTesting");
        Directory.CreateDirectory(processingFolderName);

        _logger.LogInformation("Loading files from: {dir}", processingFolderName);

        var processingDirectory = new DirectoryInfo(processingFolderName);
        return processingDirectory.EnumerateFiles("*.xml");
    }
}

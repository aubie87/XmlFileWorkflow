using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;
using XmlFileWorkflow.Core.Models.Options;

namespace XmlFileWorkflow.InputServices.ExistingFiles;
public class ExistingFilesService : IInputService
{
    private readonly ILogger<ExistingFilesService> _logger;
    private readonly IOptions<FileSystemOptions> _fileOptions;

    public ExistingFilesService(ILogger<ExistingFilesService> logger, IOptions<FileSystemOptions> fileOptions)
    {
        _logger = logger;
        _fileOptions = fileOptions;
    }

    public IEnumerable<FileInfo> FileList()
    {
        string processingFolderName = _fileOptions.Value.Folder;
        string extension = _fileOptions.Value.Extension;

        _logger.LogInformation("Loading files from: {dir}", processingFolderName);

        var processingDirectory = new DirectoryInfo(processingFolderName);
        return processingDirectory.EnumerateFiles($"*.{extension}");
    }
}

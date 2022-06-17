using Microsoft.Extensions.Options;
using XmlFileWorkflow.Core.Interfaces;
using XmlFileWorkflow.Core.Models.Options;

namespace XmlFileWorkflow.Cli.Process;

internal class ProcessWorker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplication;
    private readonly IInputService _inputService;
    private readonly IProcessingService _processingService;
    private readonly ProcessOptions _processOptions;

    public ProcessWorker(IHostApplicationLifetime hostApplication, 
        IInputService inputService, 
        IProcessingService processingService,
        IOptions<ProcessOptions> processOptions)
    {
        _hostApplication = hostApplication;
        _inputService = inputService;
        _processingService = processingService;
        _processOptions = processOptions.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(10, stoppingToken);

            if (_processOptions.Async)
            {
                var processingReport = await _processingService.ProcessFilesAsync(_inputService.FileList(), stoppingToken);
                Console.WriteLine(processingReport.GetSummary());
            }
            else
            {
                var processingReport = _processingService.ProcessFiles(_inputService.FileList());
                Console.WriteLine(processingReport.GetSummary());
            }

            // set the exit code - only useful if this is the ONLY registered worker app.
            Environment.ExitCode = 17;
            _hostApplication.StopApplication();
        }
    }
}
using XmlFileWorkflow.Core.Interfaces;

namespace XmlFileWorkflow.Cli;

public class Worker : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplication;
    private readonly IInputService _inputService;
    private readonly IProcessingService _processingService;
    private readonly bool _runAsync = false;

    public Worker(IHostApplicationLifetime hostApplication, IInputService inputService, IProcessingService processingService)
    {
        _hostApplication = hostApplication;
        _inputService = inputService;
        _processingService = processingService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if(!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(10, stoppingToken);

            if(_runAsync)
            {
                var processingReport = await _processingService.ProcessFilesAsync(_inputService.FileList(), stoppingToken);
                Console.WriteLine(processingReport.GetSummary());
            }
            else
            {
                var processingReport = _processingService.ProcessFiles(_inputService.FileList());
                Console.WriteLine(processingReport.GetSummary());
            }

            _hostApplication.StopApplication();
        }
    }
}

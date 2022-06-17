using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Core.Interfaces;

namespace XmlFileWorkflow.ProcessingServices.Processing;
public class ProcessingReport : IProcessingReport
{
    private readonly DateTime _startTime;
    private DateTime _endTime;

    /// <summary>
    /// For unit testing purposes - we should pass in an IDateTime injected instance.
    /// </summary>
    /// <param name="logger"></param>
    public ProcessingReport()
    {
        _startTime = DateTime.Now;
    }

    public void Finish()
    {
        _endTime = DateTime.Now;
    }

    public string GetSummary()
    {
        var report = new StringBuilder();
        report.AppendLine($"Started at {_startTime}");
        report.AppendLine($"End at {_endTime}");
        report.AppendLine($"Took {_endTime - _startTime}");
        return report.ToString();
    }
}

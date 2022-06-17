using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFileWorkflow.Core.Models.Options;
public class GenerateOptions
{
    public int FileCount { get; set; } = 4;
    public int StatementCount { get; set; } = 5_000;
}

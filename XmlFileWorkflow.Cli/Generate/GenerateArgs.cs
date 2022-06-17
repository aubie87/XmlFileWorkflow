using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Cli.ArgsParser;

namespace XmlFileWorkflow.Cli.Generate;

[Verb("generate", HelpText = "Generate fake sample data into a specified folder.")]
internal class GenerateArgs : BaseArgs
{
    [Option("file-count", HelpText = "Number of files to generate.")]
    public int? FileCount { get; set; }

    [Option("statement-count", HelpText = "Number of statements per file to generate.")]
    public int? StatementCount { get; set; }
}

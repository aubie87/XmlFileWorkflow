using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFileWorkflow.Cli.ArgsParser;
internal abstract class BaseArgs
{
    [Option(HelpText = "Set environment to either Production (default) or Development.")]
    public string? Environment { get; set; }

    [Option("folder", HelpText = "Processing folder path appended to current user's 'Document' folder.")]
    public string? Folder { get; set; }

    [Option("rootname", HelpText = "Root file name for input and output files.")]
    public string? Rootname { get; set; }

    [Option("extension", HelpText = "Input processing file extension.")]
    public string? Extension { get; set; }
}

using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlFileWorkflow.Cli.ArgsParser;

namespace XmlFileWorkflow.Cli.Process;

/// <summary>
/// With no args set (using defaults)
///     - synchronous and sequential
/// --async only
///     - async and sequential with overlappig awaits on DB when loading xml incrementally.
/// --xml-reader (--async optional)
///     - load xml incrementally and save to DB during load
/// --xml-serializer (--async only on DB save)
///     - load full xml model prior to saving to DB
/// --file-sequential (--async optional)
///     - load each file sequentially, complete DB save prior to starting next file.
/// --file-parallel (implies --async)
///     - load all files in parallel
/// --db-1
/// 
/// </summary>
[Verb("process", HelpText = "Process all input files in the given folder.")]
internal class ProcessArgs : BaseArgs
{
    /// <summary>
    /// Must allow null so we can determine if the arg should override app settings.
    /// </summary>
    [Option("async", HelpText = "Enables fully async processing, default is false.")]
    public bool Async { get; set; }
}

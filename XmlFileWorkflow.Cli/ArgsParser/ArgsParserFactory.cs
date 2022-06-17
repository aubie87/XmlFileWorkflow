using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFileWorkflow.Cli.ArgsParser;
public class ArgsParserFactory
{
    public static Parser GetParser()
    {
        return new Parser(
            with =>
            {
                with.CaseInsensitiveEnumValues = true;
                with.HelpWriter = Console.Error;
            }
        );
    }
}

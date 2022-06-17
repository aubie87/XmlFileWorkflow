using CommandLine;
using XmlFileWorkflow.Cli.ArgsParser;
using XmlFileWorkflow.Cli.Generate;
using XmlFileWorkflow.Cli.Process;

WriteAppVersionInfo();

await ArgsParserFactory.GetParser()
    .ParseArguments<GenerateArgs, ProcessArgs>(args)
    .MapResult(
        async (GenerateArgs options) => await GenerateHostRunner.RunAsync(args, options),
        async (ProcessArgs options) => await ProcessHostRunner.RunAsync(args, options),
        async (IEnumerable<Error> errors) => await ParsingErrors(errors)
    );

async Task ParsingErrors(IEnumerable<Error> errors)
{
    await Task.Delay(10);
    foreach(var error in errors)
    {
        Console.Error.WriteLine(error);
    }

    Environment.ExitCode = -1; // Error parsing command line.
}

void WriteAppVersionInfo()
{
    Version version = typeof(Program).Assembly.GetName().Version ?? new Version(1, 0, 0, 0);
    string progName = "XmlFileWorkflow";
    Console.WriteLine($"{progName} {version}");
    Console.WriteLine();
}

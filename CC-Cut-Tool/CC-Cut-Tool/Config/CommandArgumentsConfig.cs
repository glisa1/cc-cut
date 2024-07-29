using CommandLine;

namespace CC_Cut_Tool.Config;

internal sealed class CommandArgumentsConfig
{

    [Option('f', "field", Required = true, HelpText = "Field number.")]
    public int Field { get; init; }

    [Option('d', "delimiter", Required = false, HelpText = "Field number.", Default = '\t')]
    public char Delimiter { get; init; }

    [Value(0, HelpText = "Name of file to process.", MetaName = "File name.", Required = true)]
    public string? FileName { get; init; }

    public void Validate()
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(FileName);
    }
}

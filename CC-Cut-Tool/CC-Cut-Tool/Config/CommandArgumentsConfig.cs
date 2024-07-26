using CommandLine;

namespace CC_Cut_Tool.Config;

internal sealed class CommandArgumentsConfig
{
    [Option('f', "field", Required = true, HelpText = "Field number.")]
    public bool Field { get; init; }

    [Value(0, HelpText = "Number of field.", MetaName = "Number of field.", Required = true)]
    public int FieldNumberValue { get; init; }

    [Value(1, HelpText = "Name of file to process.", MetaName = "File name.", Required = true)]
    public string FileName { get; init; }
}

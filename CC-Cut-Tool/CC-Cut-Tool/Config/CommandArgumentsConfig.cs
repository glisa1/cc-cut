using CommandLine;

namespace CC_Cut_Tool.Config;

internal class CommandArgumentsConfig
{

    [Option('f', "field", Required = true, HelpText = "Field number.", Min = 1, Separator = ',')]
    public IEnumerable<int>? Field { get; init; }

    [Option('d', "delimiter", Required = false, HelpText = "Field number.", Default = '\t')]
    public char Delimiter { get; init; }

    public void Validate()
    {
        ArgumentNullException.ThrowIfNull(Field);
    }
}

internal sealed class CommandArgumentsConfigWithFileName : CommandArgumentsConfig
{
    [Value(0, HelpText = "Name of file to process.", MetaName = "File name.", Required = true)]
    public string? FileName { get; init; }

    public new void Validate()
    {
        base.Validate();
        ArgumentException.ThrowIfNullOrWhiteSpace(FileName);
    }
}

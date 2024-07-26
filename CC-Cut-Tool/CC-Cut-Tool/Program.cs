using CC_Cut_Tool;
using CC_Cut_Tool.Config;
using CommandLine;

internal class Program
{
    private async static Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<CommandArgumentsConfig>(args)
                .WithParsedAsync(RunWithParsedArgumentsAsync);
    }

    private static async Task RunWithParsedArgumentsAsync(CommandArgumentsConfig opts)
    {
        try
        {
            var utils = new UtilMethods();
            var cutResult = await utils.PrintCutMethodResult(opts.FileName, opts.FieldNumberValue);
            Console.WriteLine(cutResult);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}
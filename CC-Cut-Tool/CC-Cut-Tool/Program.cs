using CC_Cut_Tool.Config;
using CC_Cut_Tool.Utils;
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
            opts.Validate();
            var utils = new UtilMethods();
            var utilsDto = new UtilMethodsDTO(opts.FileName, opts.Field, opts.Delimiter);

            var cutResult = await utils.Cut(utilsDto);
            Console.WriteLine(cutResult);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}
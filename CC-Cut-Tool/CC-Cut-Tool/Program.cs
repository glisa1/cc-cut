using CC_Cut_Tool.Config;
using CC_Cut_Tool.Utils;
using CommandLine;

internal class Program
{
    private async static Task Main(string[] args)
    {
        if (Console.IsInputRedirected)
        {
            await Parser.Default.ParseArguments<CommandArgumentsConfig>(args)
                .WithParsedAsync(RunWithParsedArgumentsWithInputRedirectedAsync);
        }
        else
        {
            await Parser.Default.ParseArguments<CommandArgumentsConfigWithFileName>(args)
                    .WithParsedAsync(RunWithParsedArgumentsAsync);
        }
    }

    private static async Task RunWithParsedArgumentsAsync(CommandArgumentsConfigWithFileName opts)
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

    private static async Task RunWithParsedArgumentsWithInputRedirectedAsync(CommandArgumentsConfig opts)
    {
        try
        {
            var inputData = await Console.In.ReadToEndAsync();

            if (string.IsNullOrEmpty(inputData))
            {
                Console.Error.WriteLine("Input was empty.");
                return;
            }

            opts.Validate();
            var utils = new UtilMethods();
            var utilsDto = new UtilMethodsWithRedirectedInputDTO(inputData, opts.Field, opts.Delimiter);

            var cutResult = utils.Cut(utilsDto);
            Console.WriteLine(cutResult);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}
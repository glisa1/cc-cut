using System.Text;

namespace CC_Cut_Tool;

internal sealed class UtilMethods
{
    private const char _separator = '\t';
    public async Task<string> PrintCutMethodResult(string fileName, int fieldNumber)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllLinesAsync(fileName);

        if (text.Length == 0)
            throw new Exception("No data was read.");

        return Cut(text, fieldNumber);
    }

    private static string Cut(string[] lines, int fieldNumber)
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in lines)
        {
            var separatedValues = line.Split(_separator);

            stringBuilder.Append(separatedValues[fieldNumber - 1]).AppendLine();
        }

        return stringBuilder.ToString();
    }
}

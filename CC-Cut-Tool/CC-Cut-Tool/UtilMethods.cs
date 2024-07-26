using System.Text;

namespace CC_Cut_Tool;

internal sealed class UtilMethods
{
    private const char _defaultSeparator = '\t';
    public async Task<string> PrintCutMethodResult(string fileName, int fieldNumber)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(fieldNumber, 1);

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
            if (DoesNotContainSeparator(line))
            {
                throw new Exception("Data does not contain separator.");
            }

            var separatedValues = line.Split(_defaultSeparator);

            stringBuilder.Append(separatedValues[fieldNumber - 1]).AppendLine();
        }

        return stringBuilder.ToString();
    }

    private static bool DoesNotContainSeparator(string text, char separator = _defaultSeparator)
    {
        return !text.Contains(separator);
    }
}

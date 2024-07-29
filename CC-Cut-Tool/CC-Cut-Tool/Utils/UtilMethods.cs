using System.Text;

namespace CC_Cut_Tool.Utils;

internal sealed class UtilMethods
{
    public async Task<string> Cut(UtilMethodsDTO utilDto)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(utilDto.FieldNumber, 1);

        if (!File.Exists(utilDto.FileName))
            throw new FileNotFoundException();

        var text = await File.ReadAllLinesAsync(utilDto.FileName);

        if (text.Length == 0)
            throw new Exception("No data was read.");

        return Cut(text, utilDto.FieldNumber, utilDto.Separator);
    }

    private static string Cut(string[] lines, int fieldNumber, char separator)
    {
        var stringBuilder = new StringBuilder();

        foreach (var line in lines)
        {
            if (DoesNotContainSeparator(line, separator))
            {
                throw new Exception("Data does not contain separator.");
            }

            var separatedValues = line.Split(separator);

            stringBuilder.Append(separatedValues[fieldNumber - 1]).AppendLine();
        }

        return stringBuilder.ToString();
    }

    private static bool DoesNotContainSeparator(string text, char separator)
    {
        return !text.Contains(separator);
    }
}

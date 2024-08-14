using System.Text;

namespace CC_Cut_Tool.Utils;

public sealed class UtilMethods
{
    public async Task<string> Cut(UtilMethodsDTO utilDto)
    {
        if (!File.Exists(utilDto.FileName))
            throw new FileNotFoundException();

        var textLines = await File.ReadAllLinesAsync(utilDto.FileName);

        if (textLines.Length == 0)
            throw new Exception("No data was read.");

        return Cut(textLines, utilDto.FieldNumber, utilDto.Separator);
    }

    private static string Cut(string[] lines, IEnumerable<int> fieldNumbers, char separator)
    {
        var formatString = GetFormatString(fieldNumbers, separator);

        var stringBuilder = new StringBuilder();

        foreach (var line in lines)
        {
            if (DoesNotContainSeparator(line, separator))
            {
                throw new Exception("Data does not contain used separator.");
            }

            var separatedValues = line.Split(separator);
            List<string> cutValues = [];

            foreach (var fieldNumber in fieldNumbers)
            {
                cutValues.Add(separatedValues[fieldNumber - 1]);
            }

            stringBuilder.AppendFormat(formatString, cutValues.ToArray()).AppendLine();
        }

        return stringBuilder.ToString();
    }

    private static bool DoesNotContainSeparator(string text, char separator)
    {
        return !text.Contains(separator);
    }

    private static string GetFormatString(IEnumerable<int> fieldNumbers, char separator)
    {
        var formatStringBuilder = new StringBuilder($"{{0,-10}}{separator}");
        for (var i = 1; i < fieldNumbers.Count(); i++)
        {
            if (i == fieldNumbers.Count() - 1)
            {
                formatStringBuilder.Append($"{{{i},-10}}");
            }
            else
            {
                formatStringBuilder.Append($"{{{i},-10}}{separator}");
            }
        }

        return formatStringBuilder.ToString();
    }
}

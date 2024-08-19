namespace CC_Cut_Tool.Utils;

public sealed record UtilMethodsDTO(string FileName, IEnumerable<int> FieldNumber, char Separator);

public sealed record UtilMethodsWithRedirectedInputDTO(string Input, IEnumerable<int> FieldNumber, char Separator);

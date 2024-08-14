using CC_Cut_Tool.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_Cut_Tool.Tests
{
    public class UtilMethodsTest
    {
        private UtilMethods methodsToTest = new();
        private string tabSeparatedFilePath = $"{Environment.CurrentDirectory}\\sample.tsv";
        private string commaSeparatedFilePath = $"{Environment.CurrentDirectory}\\fourchords.tsv";

        [Fact]
        public async void UtilMethods_CutingSecondColumn_ReturnsCorrectResult()
        {
            var utilMethodsDTO = new UtilMethodsDTO(tabSeparatedFilePath, [2], '\t');

            const string expectedResult = "f1        \t\r\n1         \t\r\n6         \t\r\n11        \t\r\n16        \t\r\n21        \t\r\n";

            var result = await methodsToTest.Cut(utilMethodsDTO);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void UtilMethods_CutMethodWithFileThatDoesNotExist_ThrowsFileNotFoundException()
        {
            var utilMethodsDTO = new UtilMethodsDTO("test.txt", [2], '\t');

            var exception = await Assert.ThrowsAsync<FileNotFoundException>(async () => await methodsToTest.Cut(utilMethodsDTO));
        }
    }
}
using CC_Cut_Tool.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC_Cut_Tool.Tests
{
    public class UtilMethodsTest
    {
        private UtilMethods methodsToTest = new();
        private string tabSeparatedFilePath = $"{Environment.CurrentDirectory}\\sample.tsv";
        private string commaSeparatedFilePath = $"{Environment.CurrentDirectory}\\fourchords.small.csv";

        [Fact]
        public async void UtilMethods_CutTabSeparatedFile_ReturnsCorrectResult()
        {
            var utilMethodsDTO = new UtilMethodsDTO(tabSeparatedFilePath, [2], '\t');

            const string expectedResult = "f1        \t\r\n1         \t\r\n6         \t\r\n11        \t\r\n16        \t\r\n21        \t\r\n";

            var result = await methodsToTest.Cut(utilMethodsDTO);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void UtilMethods_CutCommaSeparatedFile_ReturnsCorrectResult()
        {
            var utilMethodsDTO = new UtilMethodsDTO(commaSeparatedFilePath, [1], ',');

            const string expectedResult = "Song title,\r\n\"10000 Reasons (Bless the Lord)\",\r\n\"20 Good Reasons\",\r\n\"Adore You\",\r\n\"Africa\"  ,\r\n";

            var result = await methodsToTest.Cut(utilMethodsDTO);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void UtilMethods_CutMethodWithFileThatDoesNotExist_ThrowsFileNotFoundException()
        {
            var utilMethodsDTO = new UtilMethodsDTO("test.txt", [2], '\t');

            await Assert.ThrowsAsync<FileNotFoundException>(async () => await methodsToTest.Cut(utilMethodsDTO));
        }

        [Fact]
        public async void UtilMethods_CutMethodWithWrongSeparatorCharacter_ThrowsExceptionThatSeparatorIsNotCorrect()
        {
            var utilMethodsDTO = new UtilMethodsDTO(tabSeparatedFilePath, [2], ',');

            var exception = await Assert.ThrowsAsync<Exception>(async () => await methodsToTest.Cut(utilMethodsDTO));

            Assert.Equal("Data does not contain used separator.", exception.Message);
        }

        [Fact]
        public async void UtilMethods_CutMethodWithFileThatIsEmpty_ThrowsExceptionThatNoDataWasRead()
        {
            var emptyFilePath = $"{Environment.CurrentDirectory}\\emptyFile.txt";
            File.Create(emptyFilePath).Dispose();
            var utilMethodsDTO = new UtilMethodsDTO(emptyFilePath, [2], '\t');

            var exception = await Assert.ThrowsAsync<Exception>(async () => await methodsToTest.Cut(utilMethodsDTO));

            Assert.Equal("No data was read.", exception.Message);
        }

        [Fact]
        public async void UtilMethods_CutMethodWithOverflowFieldNumber_ThrowsIndexOutOfRangeException()
        {
            var utilMethodsDTO = new UtilMethodsDTO(tabSeparatedFilePath, [1500], '\t');

            var exception = await Assert.ThrowsAsync<IndexOutOfRangeException>(async () => await methodsToTest.Cut(utilMethodsDTO));
        }

        [Fact]
        public async void UtilMethods_CutMethodWithNegativeFieldNumber_ThrowsIndexOutOfRangeException()
        {
            var utilMethodsDTO = new UtilMethodsDTO(tabSeparatedFilePath, [-15], '\t');

            var exception = await Assert.ThrowsAsync<IndexOutOfRangeException>(async () => await methodsToTest.Cut(utilMethodsDTO));
        }

        [Fact]
        public async void UtilMethods_CutMethodWithEmptyFileName_ThrowsFileNotFoundException()
        {
            var utilMethodsDTO = new UtilMethodsDTO("", [-15], '\t');

            var exception = await Assert.ThrowsAsync<FileNotFoundException>(async () => await methodsToTest.Cut(utilMethodsDTO));
        }
    }
}
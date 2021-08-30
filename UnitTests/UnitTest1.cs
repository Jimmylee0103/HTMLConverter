using MarkdownHTMLConverter;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void HeadingConverter_Test()
        {
            // Arrange
            var testData = "###### Heading 6";

            // Act
            var result = HTMLConverter.HeadingConverter(testData);


            // Assert

            Assert.Equal("<h6>Heading 6</h6>", result);
        }

        [Fact]
        public void LinkTextConverter_Test()
        {
            // Arrange
            var testData = "[Link text](https://www.example.com)";

            // Act
            var result = HTMLConverter.LinkTextConverter(testData);


            // Assert

            Assert.Equal("<a href=\"https://www.example.com\">Link text</a>", result);
        }

        [Fact]
        public void UnformatTextConverter_Test()
        {
            // Arrange
            var testData = "Unformatted text";

            // Act
            var result = HTMLConverter.UnformatTextConverter(testData);


            // Assert

            Assert.Equal("<p>Unformatted text</p>", result);
        }

        [Fact]
        public void ParagraphWithInlineLink_Test()
        {
            // Arrange
            var testData = "This is a paragraph [with an inline link](http://google.com). Neat, eh?";

            // Act
            var result = HTMLConverter.LinkTextConverter(testData);
            result = HTMLConverter.UnformatTextConverter(result);


            // Assert

            Assert.Equal("<p>This is a paragraph <a href=\"http://google.com\">with an inline link</a>. Neat, eh?</p>", result);
        }
    }
}

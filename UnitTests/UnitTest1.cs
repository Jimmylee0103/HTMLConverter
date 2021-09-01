using MarkdownHTMLConverter;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("# Heading 1", "<h1>Heading 1</h1>")]
        [InlineData("## Heading 2", "<h2>Heading 2</h2>")]
        [InlineData("### Heading 3", "<h3>Heading 3</h3>")]
        [InlineData("#### Heading 4", "<h4>Heading 4</h4>")]
        [InlineData("##### Heading 5", "<h5>Heading 5</h5>")]
        [InlineData("###### Heading 6", "<h6>Heading 6</h6>")]
        public void HeadingConverter_Test(string testData, string expected)
        {
            // Act
            var result = HTMLConverter.HeadingConverter(testData);


            // Assert
            Assert.Equal(expected, result);
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

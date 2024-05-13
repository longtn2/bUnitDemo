using Xunit;
using Bunit;
using BlazorSample.Pages;

public class HelloWorldTest : TestContext
{
    [Fact]
    public void HelloWorldComponentRendersCorrectly()
    {
        // Act
        var cut = RenderComponent<HelloWorld>();

        // Assert
        cut.MarkupMatches("<h1>Hello World!</h1>");
    }
}

using BlazorSample;
using BlazorSample.Layout;
using Bunit;
using Xunit;
namespace bUnitTest
{

    public class CounterCSharpTests : TestContext
    {
        [Fact]
        public void CounterStartsAtZero()
        {
            // Arrange
            var cut = RenderComponent<DoctorWhoLayout>();

            // Assert that content of the paragraph shows counter at zero
            cut.Find("header").MarkupMatches("<header><h1>Doctor Who&reg; Database</h1></header>");
        }
    }
}

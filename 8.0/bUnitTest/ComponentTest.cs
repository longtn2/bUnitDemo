using System;
using BlazorSample.Pages;
using BlazorSample.Shared;
using Microsoft.AspNetCore.Components.Web;


namespace bUnitTest
{
    public class ComponentTest : TestContext
    {
        [Fact]
        public void CatchAll()
        {
            var cut = RenderComponent<CatchAll>();

            cut.Find("p").MarkupMatches("<p>Add some URI segments to the route and request the page again.</p>");
        }
        [Fact]
        public void BindEventTest()
        {
            var component = RenderComponent<BuiltContent>();
            component.Find("button").Click();
            component.Find("div").MarkupMatches(" <div>\r\n  <h2>Pet Details</h2>\r\n  <p>Someone's best friend!</p>\r\n  <h2>Pet Details</h2>\r\n  <p>Someone's best friend!</p>\r\n  <h2>Pet Details</h2>\r\n  <p>Someone's best friend!</p>\r\n</div>");
        }
        [Fact]
        public void ClickCounterPartial()
        {
            var cut = RenderComponent<CounterPartialClass>();
            cut.Find("button").Click();
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }
        [Fact]
        public void ChildParameters()
        {
            Action<MouseEventArgs> onClickCallback = _ => { };
            var cut = RenderComponent<Child>(parameters => parameters
                .Add(p => p.Title, "Below you will find a most interesting alert!")
                .Add(p => p.OnClickCallback, onClickCallback)
                .AddChildContent("<p>Hello World</p>"));
        }
    }
}

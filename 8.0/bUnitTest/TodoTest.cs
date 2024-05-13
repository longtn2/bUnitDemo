
using System.Collections.Generic;
using BlazorSample;
using BlazorSample.Pages;

namespace bUnitTest
{
    public class TodoTest : TestContext
    {
        [Fact]
        public void ClickAddTodo()
        {
            var cut = RenderComponent<Todo>();
            cut.Find("input[placeholder='Something todo']").Change("write testcase");
            cut.Find("button").Click();
            cut.Find("li").MarkupMatches(@"<li><input type=""checkbox""/><input value=""write testcase""/></li>");
        }

        [Fact]
        public void checkTodo()
        {
            var cut = RenderComponent<Todo>();
            cut.Find("input[placeholder='Something todo']").Change("write testcase");
            cut.Find("button").Click();
            cut.Find("input[type='checkbox']").Change(false);
            var todoCountText = cut.Find("h1").TextContent;
            Assert.Contains("1", todoCountText);
        }
    }
}

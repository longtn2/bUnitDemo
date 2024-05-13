using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSample.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bUnitTest
{
    public class CallDotNet2Test : TestContext
    {
        [Fact]
        public void OnParamsSetTestCorrectly()
        {
            // Act
            var date = DateTime.Parse("12/05/2024");
            
            var cut = RenderComponent<OnParamsSet> (
                parameters => parameters
                    .Add(p => p.StartDate, date));
            // Assert
            var element = cut.Find("p:last-child");
            element.MarkupMatches($"<p>The start date in the URL was used (StartDate: {date}).</p>");
        }
        [Fact]
        public void EventHandlerTestCorrectly()
        {
            //Act
            var cut = RenderComponent<EventHandler1>();
            cut.Find("button").Click();

            //Assert
            var updatedText = cut.Find("h2");
            updatedText.MarkupMatches($"<h2>New heading ({DateTime.Now})</h2>");
        }

        [Fact]
        public void DateBindingTestCorrectly()
        {
            //Act 
            var cut = RenderComponent<DateBinding>();
            var date = DateTime.Today;
            cut.Find("input").Change(date.ToString("yyyy-MM-dd"));

            //Assert 
            var data = cut.Find("p:last-child");
            data.MarkupMatches($"<p><code>startDate</code>: {date}</p>");
        }
        [Fact]
        public void DateBindingTestErrorDate()
        {
            //Act 
            var cut = RenderComponent<DateBinding>();
            cut.Find("input").Change("2024-15/57");

            //Assert 
            var data = cut.Find("input").GetAttribute("value");
            
            data.MarkupMatches("2020-01-01");
        }
        [Fact]
        public void ControlRenderCorrectly()
        {
            //Act
            var cut = RenderComponent<ControlRender>();

            //Assert
            cut.Find("p").MarkupMatches($"<p>Current count: 0</p>");
        }
        [Fact]
        public void EventHandler2Test()
        {
            //Act
            var cut = RenderComponent<EventHandler2>();
            cut.Find("button").Click();
            
            //Assert
            cut.WaitForState(() => cut.Find("h2").TextContent == $"New heading ({DateTime.Now})", TimeSpan.FromSeconds(10));
            cut.Find("h2").MarkupMatches($"<h2>New heading ({DateTime.Now})</h2>");
        }

    }
}

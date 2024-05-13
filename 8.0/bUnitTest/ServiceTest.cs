using BlazorSample.Services;
using BlazorSample;
using BlazorSample.Shared;

namespace bUnitTest
{
    public class ServiceTest : TestContext
    {
        [Fact]
        public void disposableService()
        {
            using var ctx = new TestContext();
            var disposableService =  ctx.Services.AddTransient<TransientDisposableService>();
            Assert.NotNull(disposableService);
        }
        [Fact]
        public void TimeService()
        {
            using var ctx =new TestContext();
            var timeService = ctx.Services.AddScoped<TimerService>();
            Assert.NotNull(timeService);
        }
    }
}

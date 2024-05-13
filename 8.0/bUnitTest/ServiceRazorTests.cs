using BlazorSample;
using BlazorSample.Services;

namespace bUnitTest
{
    public class ServiceRazorTests : TestContext
    {
        [Fact]
        public void DisposableService()
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

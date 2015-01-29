using Nancy.Testing;
using NUnit.Framework;
using ScottyTestsWebHarness;

namespace ScottyTestsTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void CanRun()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                var module = new TestRunnerModule();
                with.Module(module);
            });
            var browser = new Browser(bootstrapper);

            var result = browser.Get("/", with => with.HttpRequest());
        }

    }
}

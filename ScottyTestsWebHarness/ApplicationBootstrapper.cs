using Nancy;
using Nancy.Conventions;

namespace ScottyTestsWebHarness
{
   public class ApplicationBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            //nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory//("static", @"static"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}

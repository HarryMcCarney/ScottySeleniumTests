using System;
using ScottyTestsWebHarness;
using Topshelf;

[assembly: Microsoft.Owin.OwinStartup(typeof(Startup))]
namespace ScottyTestsWebHarness
{

    
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(x =>
            {
                x.Service<ScottySeleniumTestsService>(s =>
                {
                    s.ConstructUsing(name => new ScottySeleniumTestsService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                //x.RunAs("Domain\\User", "pwd");

                const string serviceName = "ScottySeleniumTests";
                x.SetDescription(serviceName);
                x.SetDisplayName(serviceName);
                x.SetServiceName(serviceName);
            });                          

            }

      
    }

    
}

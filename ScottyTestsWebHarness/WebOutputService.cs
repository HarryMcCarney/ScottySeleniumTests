using System;
using Nancy.Hosting.Self;

namespace ScottyTestsWebHarness
{
    internal class ScottySeleniumTestsService
    {
        private NancyHost Host { get; set; }

        public ScottySeleniumTestsService()
        {
            var config = new HostConfiguration();
            var urls = new UrlReservations { CreateAutomatically = true };
            config.UrlReservations = urls;
            var uri = new Uri("http://localhost:8887");
            Host = new NancyHost(config, uri);
        }

        public void Start()
        {
            Host.Start();
        }
    
        public void Stop()
        {
            Host.Stop();
        }

      
    }
}

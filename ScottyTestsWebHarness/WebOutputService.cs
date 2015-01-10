using Microsoft.Owin.Hosting;

namespace ScottyTestsWebHarness
{
    internal class ScottySeleniumTestsService
    {
        private bool InProcess { get; set; }
    
        public void Start()
        {
            StartNancy(); ;
        }
    
        public void Stop()
        {
            InProcess = false;
        }

        private void StartNancy()
        {
            string url = "http://localhost:8887";
            using (WebApp.Start<Startup>(url))
            {
                InProcess = true;
                while (InProcess)
                {
                
                }
            }
        }
    }
}

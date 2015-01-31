using System;
using System.Threading;
using Nancy;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScottyTestsCore;


namespace ScottyTestsWebHarness
{
    public class TestRunnerModule : NancyModule
    {
        private string RunId { get; set; }
    
        public TestRunnerModule()
        {
            Get["/"] = x => Start();
            Get["Status"] = x => Status();
        }

        private string Status()
        {
            return JsonConvert.SerializeObject(TestRunResults.Instance.GetRun(Request.Query.Id));
        }

        private string Start()
        {
            RunId = TestRunResults.Instance.CreateRun();
            new Thread(RunTests).Start();
            return JsonConvert.SerializeObject(TestRunResults.Instance.GetRun(RunId)); ;
        }

        private void RunTests()
        {
            BrowserRun(new ChromeDriver(), TestRunResults.Instance.GetRun(RunId));
        }

        private void BrowserRun(IWebDriver driver, TestRunResult result )
        {
            var browser = new Browser(driver, result);
            try
            {
                TestRunResults.Instance.SetRun(RunId, null, RunStatus.Running);
                var candidate = new CandidateSignUp(browser);
                candidate.Create();
                var emplopyer = new EmployerSignUp(browser);
                emplopyer.Create();
                browser.Close();
                TestRunResults.Instance.SetRun(RunId, null, RunStatus.Success);
            }
            catch (Exception exp)
            {
                browser.Close();
            }


        }


    }
}

using System;
using System.Threading;
using Nancy;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using ScottySeleniumTests;
using TestingPhanomJs;

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

        private dynamic Start()
        {
            RunId = TestRunResults.Instance.CreateRun();
            new Thread(RunTests).Start();
            return RunId;
        }

        private void RunTests()
        {
            var browser = new Browser(new ChromeDriver(), TestRunResults.Instance.GetRun(RunId));
            try
            {
                TestRunResults.Instance.SetRun(RunId,null, RunStatus.Running);
                var candidate = new CandidateSignUp(browser);
                candidate.Create();
                var emplopyer = new EmployerSignUp(browser);
                emplopyer.Create();
                browser.Close();
                TestRunResults.Instance.SetRun(RunId, null, RunStatus.Sucess);
            }
            catch (Exception exp)
            {
                browser.Close();
            }


        }


    }
}

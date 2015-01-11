using System;
using System.Collections.Generic;
using System.Linq;

namespace ScottyTestsCore
{
    public class TestRunResults
    {
        

        private static TestRunResults instance = new TestRunResults();

        private List<TestRunResult> Results { get; set; }

        public static TestRunResults Instance
        {
            get { return instance; }
        }

        private TestRunResults()
        {
           Results = new List<TestRunResult>();
        }

        public string CreateRun()
        {
            var id = Guid.NewGuid().ToString();
            Results.Add(new TestRunResult{Id = id});
            return id;
        }

        public TestRunResult GetRun(string id)
        {
            return (from x in Results where x.Id == id select x).FirstOrDefault();
        }

        public void SetRun(string id, string message, RunStatus status)
        {
            var run = (from x in Results where x.Id == id select x).FirstOrDefault();
            run.Message = message;
            run.RunStatus = status;
        }


    }

    public class TestRunResult
    {
        public string Message { get; set; }
        public RunStatus RunStatus { get; set; }
        public string Id { get; set; }
        public string Status {
            get { return Enum.GetName(typeof(RunStatus), RunStatus); }
            
        }
    }


    public enum RunStatus
    {
        Pending,
        Running,
        Failed,
        Sucess
    }
}


using OpenQA.Selenium.Chrome;
using ScottySeleniumTests;

namespace TestingPhanomJs
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = new Browser(new ChromeDriver());
            var candidate = new CandidateSignUp(browser);
            candidate.Create();


            var emplopyer = new EmployerSignUp(browser);
            emplopyer.Create();




        }
    }
}

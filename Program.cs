using OpenQA.Selenium.Chrome;

namespace TestingPhanomJs
{
    class Program
    {
        static void Main(string[] args)
        {

            //var candidate = new CandidateSignUp(new Browser(new ChromeDriver()));
            //candidate.Create();


            var emplopyer = new EmployerSignUp(new Browser(new ChromeDriver()));
            emplopyer.Create();




        }
    }
}

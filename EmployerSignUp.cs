using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ScottySeleniumTests;
using ScottyTestsWebHarness;

namespace TestingPhanomJs
{
    public class EmployerSignUp
    {
        public Browser Browser { get; set; }
        private string Email { get; set; }

        public EmployerSignUp(Browser browser)
        {
            Email = Guid.NewGuid().ToString() + "@hackandcraft.com";
            Browser = browser;
        }

        public void Create()
        {
            Browser.Navigate("http://scotty-dev.s3-website-eu-west-1.amazonaws.com/employer/#/signup/start/");
            Start();
            BasicInformation();
            Offices();
            Facts();
            Tech();
            Benefits();
            Terms();
        }

        private void Start()
        {
            try
            {
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[1]/div[1]/input").
                SendKeys(Guid.NewGuid().ToString());
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[2]/div[1]/label[2]/input").
                Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[3]/div[1]/select[1]/option[3]").
                Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[4]/div[1]/input").SendKeys("Sally");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[5]/div[1]/input").SendKeys("Selenium");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[6]/div[1]/input").SendKeys(Email);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[7]/div[1]/input").SendKeys("Popov2010");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[2]/button").
                    Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void BasicInformation()
        {
            try
            {
                Thread.Sleep(4000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[1]/div[1]/div[1]").
                Click();
                Thread.Sleep(2000);
                var logo = Directory.GetCurrentDirectory() + "\\Review.png";
                Console.WriteLine(logo);
                SendKeys.SendWait(logo);
                SendKeys.SendWait(@"{Enter}");

                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div[1]/input")
                    .SendKeys("https://www.google.co.uk");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[3]/div/input")
                    .SendKeys("https://www.facebook.com/HackAndCraft");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[4]/div/input")
                    .SendKeys("https://www.linkedin.com/profile/view?id=41874792");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[2]/button")
                    .Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void Offices()
        {
            try
            {
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[2]/div[1]/input").SendKeys("123 The Avenue");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[2]/div[3]/input").SendKeys("Beverly Hills");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[2]/div[4]/input").SendKeys("10247");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[2]/div[5]/div/div[2]/input").SendKeys("Berlin");

                Thread.Sleep(1000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[7]/div/div/input").SendKeys("Managing Director");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[8]/div/div/input").SendKeys("01273553567");


                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[4]/div/div/select[1]/option[3]").
                Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[5]/div/div/input").SendKeys("Sally");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[6]/div/div/input").SendKeys("Selenium");

                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[9]/div/div/input").Clear();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/div[9]/div/div/input").SendKeys(Email);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-offices/div/hc-office-form/form/div/span/div/div/button[1]").Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/div/button").Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void Facts()
        {
            try
            {
                Thread.Sleep(1000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/div[1]/div/input").SendKeys("2010");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/div[2]/div[1]/div/input").SendKeys("200000");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/div[3]/div/input").SendKeys("20");
                SendKeys.SendWait(@"{Tab} Our mission is to roll that boulder up the hill again and again with a serene look of contentment on our faces.");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[2]/button").Click();

            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void Tech()
        {
            try
            {
                Thread.Sleep(1000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/div[1]/div[1]/input").SendKeys("20");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/div[2]/div/hc-label-typeahead/input").SendKeys("Java");
                Thread.Sleep(2000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);

                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[2]/button").Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void Benefits()
        {
            try
            {
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/hc-benefits-edit/ul/li[1]/label/input").Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/hc-benefits-edit/ul/li[19]/label/input").Click();
                SendKeys.SendWait(@"{Tab} Boulder polishing");
                SendKeys.SendWait(@"{Tab} We do several boulder rolling tests during the interview");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[2]/button").Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

        private void Terms()
        {
            try
            {
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[1]/label/input").Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/form/div[1]/div/div[2]/button").Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                throw;

            }

        }

    }
}

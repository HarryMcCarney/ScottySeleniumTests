using System;
using System.Threading;


namespace ScottyTestsCore
{
    public class CandidateSignUp
    {
        public Browser Browser { get; set; }
        private string Email { get; set; }

        public CandidateSignUp(Browser browser)
        {
            Email = Guid.NewGuid().ToString() + "@hackandcraft.com";
            Browser = browser;
        }

        public void Create()
        {
            TargetPosition();
            SignUp(); 
            Experience();
            Education();
            Skills();
            Languages();
            FinalStep();
            ConfirmEmail();
            //Login();

        }

        private void TargetPosition()
        {
            try
            {
               
                Browser.GetElement("//*[@id=\"content\"]/div[3]/div[2]/a").Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[1]/div/select[1]/option[3]")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div[2]/div/div[1]/label/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div[2]/div/div[4]/label/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[3]/div[1]/hc-label-typeahead/input")
                    .SendKeys("Selenium");
                Browser.GetElement(
                    " //*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[4]/div[2]/div/input")
                    .SendKeys("50000");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[5]/div[2]/div[2]/div[1]/div[1]/label/input")
                    .
                    Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[2]/div/div/button")
                    .Click();
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/hc-connectors-buttons/div/div/hc-linkedin-connect/div[2]")
                    .Click();

            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }

        }

        private void SignUp()
        {
            try
            {
                Browser.GetElement("//*[@id=\"session_key-oauth2SAuthorizeForm\"]").SendKeys("hmccarney@gmail.com");
                Browser.GetElement("//*[@id=\"session_password-oauth2SAuthorizeForm\"]").SendKeys("Popov2010");
                Browser.GetElement("//*[@id=\"body\"]/div/form/div[2]/ul/li[1]/input").Click();
                Thread.Sleep(4000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[2]/div[1]/input")
                    .Clear();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[2]/div[1]/input")
                    .SendKeys("Selenium");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[3]/div[1]/input")
                    .Clear();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[3]/div[1]/input")
                    .SendKeys(Email);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[4]/div[1]/input")
                    .SendKeys("Popov2010");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[1]/div[6]/div/label/input").Click();
                Thread.Sleep(3000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/form/div/div[2]/button").Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }

        private void Experience()
        {
            try
            {
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li/div/div[5]/div/div[4]/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li/div/div[6]/div/div[4]/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li/div/div[16]/button")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[1]/div[1]/input")
                    .SendKeys("Selennium LTD");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[2]/div/div/div[2]/input")
                    .SendKeys("Berlin");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/select[1]/option[3]")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[3]/div/div/div[1]/div[1]/div[2]/input")
                    .SendKeys("2002");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[3]/div/div/div[2]/div[4]/div/label/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[4]/div/input")
                    .SendKeys("Chief Boulder Roller");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[1]/div[5]/div/textarea")
                    .SendKeys("I was responsible for boulder rolling");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[2]/div/div[2]/div[1]/div[1]/label/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li[2]/hc-experience-form/form/div/div[3]/div/div/button[1]")
                    .
                    Click();
                Thread.Sleep(4000);
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/div/button").
                    Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }

        private void Education()
        {
            try
            {
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li/div/div[5]/div/div[4]/input")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/ul/li/div/div[6]/div/div[4]/input")
                    .Click();
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/div/button")
                    .Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }



        private void Skills()
        {
            try
            {
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-skills-form/form/div[1]/div/div[2]/div/div/div[2]/select[1]/option[2]")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-skills-form/form/div[1]/div/div[3]/div/div/div[2]/select[1]/option[4]")
                    .Click();

                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-skills-form/form/div[1]/div/div[4]/div/div/div[1]/input")
                    .SendKeys("Selenium");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-skills-form/form/div[1]/div/div[4]/div/div/div[2]/select[1]/option[2]")
                    .Click();
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-skills-form/form/div[2]/div/button")
                    .Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }

        private void Languages()
        {
            try
            {
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-languages-form/form/div[1]/div[1]/div/div[1]/div/div[2]/select[1]/option[2]")
                    .Click();

                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-languages-form/form/div[1]/div[1]/div/div[2]/div/div[2]/select[1]/option[2]")
                    .Click();

                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/hc-languages-form/form/div[2]/div/button")
                    .
                    Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }

        private void FinalStep()
        {
            try
            {
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]//ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[1]/div[1]/input")
                    .SendKeys("Berlin");
                Thread.Sleep(2000);
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[1]/div[1]/input")
                    .SendKeys(", DE");
                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div/div[1]/div[1]/input")
                    .SendKeys("06");

                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div/div[1]/div[2]/select[1]/option[4]")
                    .Click();
                Browser.GetElement(
                   "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[1]/div[2]/div/div[1]/div[3]/input")
                   .SendKeys("1979");


                Browser.GetElement(
                    "//*[@id=\"content\"]/ui-view/div/div[2]/ui-view/div/div[1]/div/form/div[2]/div/button")
                    .
                    Click();
            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }


        private void ConfirmEmail()
        {   
            try
            {
                Thread.Sleep(2000);
                Browser.Navigate("https://mail.google.com/");
                Browser.GetElement("//*[@id=\"Email\"]").SendKeys("catch@hackandcraft.com");
                Browser.GetElement("//*[@id=\"Passwd\"]").SendKeys("Popov2010");
                Browser.GetElement("//*[@id=\"signIn\"]").Click();


                Browser.GetElement("//div [@class='y6']/span[contains(.,'Please confirm your registration')]").Click();
                Thread.Sleep(3000);
                Browser.GetElementCSS("a[href*='scotty-dev.s3-website-eu-west-1.amazonaws.com']").Click();
                Browser.CloseOtherTab();

            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }

        private void Login()
        {
            try
            {
                Browser.Navigate("http://scotty-dev.s3-website-eu-west-1.amazonaws.com/candidate/#/login/");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/form/div/div[1]/div/input").
                    SendKeys(Email);

                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/form/div/div[2]/div/input").
                    SendKeys("Popov2010");
                Browser.GetElement("//*[@id=\"content\"]/ui-view/div/form/div/div[3]/div/div/button").
                    Click();
                Thread.Sleep(2000);
                Browser.GetElement("/html/body/div[2]/ng-include/nav/div/div[2]/ul[2]/li[3]/a").Click();



            }
            catch (Exception exp)
            {
                Browser.Results.RunStatus = RunStatus.Failed;
                Browser.Results.Message = exp.Message;
                Browser.UploadScreenShot();
                throw;

            }
        }
    }
}


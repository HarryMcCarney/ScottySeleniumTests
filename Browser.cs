using System;
using System.Drawing.Imaging;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ScottySeleniumTests
{
    class Browser
    {
        private ChromeDriver Driver { get; set; }

        public Browser(ChromeDriver  driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Navigate("http://scotty-dev.s3-website-eu-west-1.amazonaws.com/");
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public IWebElement GetElement(string path)
        {
            try
            {
            
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
                return Driver.FindElementByXPath(path);
            }
            catch (Exception exp)
            {
                Driver.GetScreenshot().SaveAsFile("screenshot"+DateTime.Now.Ticks.ToString()+".png", ImageFormat.Png);
                Thread.Sleep(5000);
                return GetElement(path);
            }
         }

        public IWebElement GetElementCSS(string path)
        {
            try
            {

                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(path)));
                

                return Driver.FindElementByCssSelector(path);
            }
            catch (Exception exp)
            {
                Driver.GetScreenshot().SaveAsFile("screenshot" + DateTime.Now.Ticks.ToString() + ".png", ImageFormat.Png);
                Thread.Sleep(5000);
                return GetElementCSS(path);
            }
        }


        public bool Exists( By locator)
        {
            try
            {
                Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException) { return false; }
        }


      





    }
}

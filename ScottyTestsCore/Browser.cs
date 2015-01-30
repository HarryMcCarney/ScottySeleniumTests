using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ScottyTestsCore
{
    public class Browser
    {
        private ChromeDriver Driver { get; set; }
        public TestRunResult Results { get; set; }

        public Browser(ChromeDriver  driver, TestRunResult results)
        {
            Driver = driver;
            Results = results;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
            Navigate("http://scotty-dev.s3-website-eu-west-1.amazonaws.com/");
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public void Close()
        {
            foreach (var handle in Driver.WindowHandles)
            {
                Driver.SwitchTo().Window(handle);
                Driver.Close();
            }
        }

        public IWebElement GetElement(string path, int? retries = null)
        {
            if (retries == null)
                retries = 3;
            try
            {
                
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
                return Driver.FindElementByXPath(path);
            }
            catch (Exception exp)
            {
                retries = retries - 1;
                
                if (retries > 0)
                {
                    Thread.Sleep(5000);
                    return GetElement(path, retries);
                }
               
                
                throw exp;
            }
         }

        public void UploadScreenShot()
        {
            var screenshot = "screenshot" + DateTime.Now.Ticks.ToString() + ".png";

            Driver.GetScreenshot().SaveAsFile(screenshot, ImageFormat.Png);
            var storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=booksys;AccountKey=BS323SGwtVqgJF+mx3JGpWF81e4rGqt7CHUEJoeu4SsBtO+S+lm9tmx1E6qG68VQ6WFhSPliPMs7ji4QMaTjEQ==");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("scottyseleniumscreenshots");
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var blockBlob = container.GetBlockBlobReference(screenshot);
           
            using (var fileStream = System.IO.File.OpenRead(screenshot))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            Results.ScreenShotUrl = "https://booksys.blob.core.windows.net/scottyseleniumscreenshots/" + screenshot;
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

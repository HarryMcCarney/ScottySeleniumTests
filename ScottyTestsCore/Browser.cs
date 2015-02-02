using System;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ScottyTestsCore
{
    public class Browser
    {
        private IWebDriver Driver { get; set; }
        public TestRunResult Results { get; set; }

        public Browser(IWebDriver driver, TestRunResult results)
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


        public void CloseOtherTab()
        {
            var currentHandle = Driver.CurrentWindowHandle;
            foreach (var handle in Driver.WindowHandles)
            {
                if (handle != currentHandle)
                {
                    Driver.SwitchTo().Window(handle);
                    Driver.Close();
                    Driver.SwitchTo().Window(currentHandle);
                }
                
            }
         
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
                return Driver.FindElement(By.XPath(path));
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
            var imagefile = "screenshot" + DateTime.Now.Ticks.ToString() + ".png";
            var screenshot = ((ITakesScreenshot) Driver).GetScreenshot();
            screenshot.SaveAsFile(imagefile, ImageFormat.Png);
            var storageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=booksys;AccountKey=BS323SGwtVqgJF+mx3JGpWF81e4rGqt7CHUEJoeu4SsBtO+S+lm9tmx1E6qG68VQ6WFhSPliPMs7ji4QMaTjEQ==");
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("scottyseleniumscreenshots");
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var blockBlob = container.GetBlockBlobReference(imagefile);

            using (var fileStream = System.IO.File.OpenRead(imagefile))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            Results.ScreenShotUrl = "https://booksys.blob.core.windows.net/scottyseleniumscreenshots/" + imagefile;
        }

        public IWebElement GetElementCSS(string path)
        {
            try
            {

                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(path)));
                

                return Driver.FindElement(By.CssSelector(path));
            }
            catch (Exception exp)
            {
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

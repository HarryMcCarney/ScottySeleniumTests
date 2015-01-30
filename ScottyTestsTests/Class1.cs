using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Nancy.Testing;
using NUnit.Framework;
using ScottyTestsWebHarness;

namespace ScottyTestsTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void CanRun()
        {
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                var module = new TestRunnerModule();
                with.Module(module);
            });
            var browser = new Browser(bootstrapper);

            var result = browser.Get("/", with => with.HttpRequest());
        }


        [Test]
        public void CanUploadPicture()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("scottyseleniumscreenshots");
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            var blockBlob = container.GetBlockBlobReference("profilePicture.jpg");
            using (var fileStream = System.IO.File.OpenRead("C:\\Scotty\\SeleniumTests\\ScottyTestsTests\\profilePicture.jpg"))
            {
               blockBlob.UploadFromStream(fileStream);
            } 

        }




        }

}


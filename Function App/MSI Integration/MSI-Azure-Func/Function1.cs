using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System;

namespace MSI_Blob
{
    public static class Function1 
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            string accessToken = await azureServiceTokenProvider.GetAccessTokenAsync("https://storage.azure.com");


            log.LogInformation("accessToken : retrieved");


            // create the credential, using the 
            var tokenCredential = new TokenCredential(accessToken);
            var storageCredentials = new StorageCredentials(tokenCredential);

            log.LogInformation("credentials : created");
            var storageURL = "https://ovcmsifuncapp.blob.core.windows.net/files/";
            var fileName = "append";
            var Uri = new Uri(storageURL + fileName);
            var blob = new CloudAppendBlob(Uri, storageCredentials);

            log.LogInformation($"blobfile : setup {0}", Uri);

            if (!(await blob.ExistsAsync()))
            {
                await blob.CreateOrReplaceAsync(AccessCondition.GenerateIfNotExistsCondition(), null, null);
            }

            await blob.AppendTextAsync(name);

            var fileName2 = "regular.txt";
            var Uri2 = new Uri(storageURL + fileName2);
            var blob2 = new CloudBlockBlob(Uri2, storageCredentials);

            await blob2.UploadTextAsync(name);

            return name != null
            ? (ActionResult)new OkObjectResult($"Hello, {name}")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
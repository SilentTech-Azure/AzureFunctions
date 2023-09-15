using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
//=sing Microsoft.Azure.WebJobs.ServiceBus;

namespace Blobtrigger
{
    public class Function1
    {
        [FunctionName("Function1")]
        [return: ServiceBus("servicebusqueue", Connection = "AzureWebJobsServiceBus")]
        public string Run([BlobTrigger("anvicontainer/{name}", 
            Connection = "AzureWebJobsStorage")]Stream myBlob,
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: " +
                $"{myBlob.Length} Bytes");

            return $"Inserted File Name:- {name}";
        }
    }
}
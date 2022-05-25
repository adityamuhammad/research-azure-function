using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Research1
{
    public static class Research3
    {
        [FunctionName("Research3")]
        public static void Run([BlobTrigger("research-blob/{name}")] Stream myBlob, string blobTrigger, string name, ILogger log)
        {
            using var reader = new StreamReader(myBlob);
            log.LogInformation(@$"
                C# Blob trigger function Processed blob\n 
                Name:{name} \n 
                Size: {myBlob.Length} Bytes\n
                Content: {reader.ReadToEnd()}
                Path: {blobTrigger}
            ");
        }
    }
}

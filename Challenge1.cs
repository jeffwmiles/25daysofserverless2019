using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class Challenge1
    {
        [FunctionName("Challenge1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Declare and initialize a string array with our choices of characters
            string[] options;
            options = new string[4] { "נ (nun)", "ג (gimel)", "ה (hei)", "ש (shin)" };
            // populate a result variable by grabbing a random integer choice between zero and the lengh of the array
            var result = options[new Random().Next(0, options.Length)];
            // If not null, return the result to the HTTP request
            return result != null
                ? (ActionResult)new OkObjectResult($"Result: {result}")
                : new BadRequestObjectResult("Something went wrong");
        }
    }
}

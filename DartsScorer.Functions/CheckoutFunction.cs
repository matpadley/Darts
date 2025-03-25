using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DartsScorer.Main.Checkout;

public static class CheckoutFunction
{
    [FunctionName("CheckoutFunction")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        int score = data?.score;

        if (score < 2 || score > 170)
        {
            return new BadRequestObjectResult("Please pass a number between 2 and 170 in the request body");
        }

        var calculator = new CheckoutCalculator();
        var result = calculator.Calculate(score);

        return new OkObjectResult(result);
    }
}

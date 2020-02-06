#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
     var username =  Environment.GetEnvironmentVariable("UsernameFromKeyVaullt", EnvironmentVariableTarget.Process);
    var password =  Environment.GetEnvironmentVariable("PasswordFromKeyVaullt", EnvironmentVariableTarget.Process);

    string name = req.Query["name"];

    log.LogInformation($"Username: {username}");
    log.LogInformation($"Password: {password}");

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    return name != null
        ? (ActionResult)new OkObjectResult($"Username: {username}  Password: {password} ")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}

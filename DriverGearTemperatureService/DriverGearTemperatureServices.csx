#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;


public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("Drive Gear Temperature Service triggered");

    if (req.Body != null)
    {          
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        var readings = data?.readings;

        if (readings == null)
        {
           return new OkObjectResult("No readings found"); 
        }

        foreach(var reading in readings)
        {
            if(reading.temperature<=25) {
                reading.status = "OK";
            } else if (reading.temperature<=50) {
                reading.status = "CAUTION";
            } else {
                reading.status = "DANGER";
            }
            string status = reading["status"];
            log.LogInformation("Reading  " + status);
        }        
        return new OkObjectResult(readings);
    }
}

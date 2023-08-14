using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class CallController : ControllerBase
   {
      private static readonly string[] Summaries = new[]
      {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

      private readonly ILogger<WeatherForecastController> _logger;

      public CallController(ILogger<WeatherForecastController> logger)
      {
         _logger = logger;
      }

      [HttpGet(Name = "GetDataInfo")]
      public IActionResult GetDataInfo([FromBody] object requestBody)
      {
         //_logger.LogInformation("Received request with body: {RequestBody}", requestBody);

         if (!System.IO.Directory.Exists("C:\\Temp"))
         {
            System.IO.Directory.CreateDirectory("C:\\Temp");
         }
         using (StreamWriter writer = new StreamWriter("C:\\Temp\\" + Guid.NewGuid().ToString()))
         {

            using (JsonDocument doc = JsonDocument.Parse(requestBody.ToString()))
            {
               JsonElement jsonElement = doc.RootElement;
               writer.WriteLine(jsonElement.ToString());

            }
         }



         return Ok();
      }
   }
}

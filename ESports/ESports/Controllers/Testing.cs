using CommunicationChannel;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ESports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testing : ControllerBase
    {
        private readonly ILogger<Testing> _log;
        public Testing(ILogger<Testing> logger)
        {
            _log = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            
            Log.Information("Hello");
            //XmlConfigurator.Configure(new FileInfo("./App.xml"));
            //_log.LogInformation("Added info Sucessfully");
            //_log.LogWarning("Added warn Sucessfully");
            //_log.LogError("Added errrr Sucessfully");
            //_log.LogCritical("Added fattal Sucessfully");
            //Client client = new Client("http://localhost:5112");
            //var x = await client.GameGETAsync("BGMI");
            return Ok();
        }
    }
}

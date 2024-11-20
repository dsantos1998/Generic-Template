using DSM.MJMLEditor.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net.Mime;
using System.Reflection.Emit;

namespace DSM.MJMLEditor.APIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [EnableRateLimiting("all-limiter")]
    [ProducesResponseType(typeof(string), StatusCodes.Status429TooManyRequests)]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            string? connectionString = _configuration.GetConnectionString(_configuration["ActiveConnection"]);
            return Ok($"Great! - {Labels.Example} - {connectionString}");
        }
    }
}

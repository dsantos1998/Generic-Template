using EnterpriseName.SolutionName.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Reflection.Emit;

namespace EnterpriseName.SolutionName.APIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    //[EnableRateLimiting("all-limiter")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok($"Great! - {Labels.Example}");
        }
    }
}

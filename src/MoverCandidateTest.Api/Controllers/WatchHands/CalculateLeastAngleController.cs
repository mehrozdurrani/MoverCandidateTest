using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoverCandidateTest.Contracts.WatchHands;
using MoverCandidateTest.Services.WatchHands;

namespace MoverCandidateTest.Controllers.WatchHands
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateLeastAngleController : ControllerBase
    {
        private readonly ILogger<CalculateLeastAngleController> _logger;
        private readonly ICalculateLeastAngleService _calculateLeastAngleService;

        public CalculateLeastAngleController(ILogger<CalculateLeastAngleController> logger, ICalculateLeastAngleService calculateLeastAngleService)
        {
            _logger = logger;
            _calculateLeastAngleService = calculateLeastAngleService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CalculateLeastAngleRequest request)
        {
            CalculateLeastAngleResponse response = _calculateLeastAngleService.CalculateLeastAngle(request.DateTime);
            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoverCandidateTest.Api.Controllers;
using MoverCandidateTest.Contracts.WatchHands;
using MoverCandidateTest.Services.WatchHands;

namespace MoverCandidateTest.Controllers.WatchHands
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateLeastAngleController : ApiController
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
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState of the request is not valid");
                return BadRequest(ModelState);
            }
            var leastAngle = _calculateLeastAngleService.CalculateLeastAngle(request.DateTime);
            CalculateLeastAngleResponse response = new CalculateLeastAngleResponse(request.DateTime.ToString("h:mm tt"), leastAngle);
            return Ok(response);
        }
    }
}

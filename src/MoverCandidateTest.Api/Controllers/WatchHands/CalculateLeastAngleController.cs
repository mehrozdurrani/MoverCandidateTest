using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoverCandidateTest.Contracts.WatchHands;

namespace MoverCandidateTest.Controllers.WatchHands
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateLeastAngleController : ControllerBase
    {
        private readonly ILogger<CalculateLeastAngleController> _logger;

        public CalculateLeastAngleController(ILogger<CalculateLeastAngleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery] CalculateLeastAngleRequest requestModel)
        {
            return $"Hi candidate, return your result here :) (Input reads: {requestModel.DateTime})";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoverCandidateTest.Contracts.WatchHands;
using MoverCandidateTest.Controllers.WatchHands;
using MoverCandidateTest.Services.WatchHands;

namespace MoverCandidateTest.Api.UnitTests.WatchHands
{
    public class CalculateLeastAngleControllerTests
    {
        private Mock<ILogger<CalculateLeastAngleController>> _logger;
        private Mock<ICalculateLeastAngleService> _calculateLeastAngleService;
        private CalculateLeastAngleController _calculateLeastAngleController;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<CalculateLeastAngleController>>();
            _calculateLeastAngleService = new Mock<ICalculateLeastAngleService>();
            _calculateLeastAngleController = new CalculateLeastAngleController(_logger.Object, _calculateLeastAngleService.Object);
        }

        [Test]
        [TestCase("11/25/2020 4:07:12 PM")]
        [TestCase("11/25/2020 6:00:00 PM")]
        public void Get_ValidRequest_ReturnsOkAndCalculateLeastAngleResponse(string dateTime)
        {
            CalculateLeastAngleRequest request = new CalculateLeastAngleRequest
            {
                DateTime = DateTime.Parse(dateTime)
            };

            //Act
            var result = _calculateLeastAngleController.Get(request);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            var calculateLeastAngleResponse = okResult.Value;

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(calculateLeastAngleResponse, Is.TypeOf<CalculateLeastAngleResponse>());
            _calculateLeastAngleService.Verify(x => x.CalculateLeastAngle(It.IsAny<DateTime>()), Times.Once);
        }

        /*
        IMPORTANT: The intend was to implement 'Get_InvalidRequest_ReturnsBadRequest' but it was not possible to do so.
        as any invalid time or date cannot reach the 'CalculateLeastAngleController' as exaception will be handled 
        in the pipline. It doesnt seem possible to product invalid date as "DateTime' cannot be initialized with
        invalid date or time".
        */
    }
}
using Microsoft.Extensions.Logging;
using Moq;
using MoverCandidateTest.Services.WatchHands;

namespace MoverCandidateTest.Services.UnitTests.WatchHands
{
    [TestFixture]
    public class CalculateLeastAngleServiceTests
    {
        private ICalculateLeastAngleService _calculateLeastAngleService;
        private ILogger<CalculateLeastAngleService> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<CalculateLeastAngleService>>().Object;
            _calculateLeastAngleService = new CalculateLeastAngleService(_logger);
        }

        [Test]
        [TestCase("11/25/2020 4:07:12 PM", 81.5)]
        [TestCase("11/25/2020 6:00:00 PM", 180.0)]
        [TestCase("11/25/2020 7:15:00 PM", 127.5)]
        [TestCase("11/25/2020 9:35:00 PM", 77.5)]
        [TestCase("11/25/2020 12:00:00 PM", 00.0)]
        public void CalculateLeastAngle_WhenCalled_ReturnsSmallestAngle(string dateTimeString, double minimumAngle)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateTimeString);

            // Act
            _calculateLeastAngleService.CalculateLeastAngle(dateTime);

            // Assert
            Assert.That(_calculateLeastAngleService.CalculateLeastAngle(dateTime), Is.EqualTo(minimumAngle));
        }
    }
}
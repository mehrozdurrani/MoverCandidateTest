using Microsoft.Extensions.Logging;

namespace MoverCandidateTest.Services.WatchHands
{
    public class CalculateLeastAngleService : ICalculateLeastAngleService
    {
        private readonly ILogger<CalculateLeastAngleService> _logger;

        public CalculateLeastAngleService(ILogger<CalculateLeastAngleService> logger)
        {
            _logger = logger;
        }

        /*
        IMPORTANT: The model validation of 'dateTime' is done in the controller. 
        The DateTime that is passed will always be valid. So 'CalculateLeastAngle' 
        doesnt need validation of the passed object
        */

        public double CalculateLeastAngle(DateTime dateTime)
        {
            // Get the hour and minute from the request
            var hour = dateTime.Hour % 12;
            var minute = dateTime.Minute;

            // Calculate the smallest angle between the hour and minute hand
            var hourAngle = hour * 30 + minute * 0.5;
            var minuteAngle = minute * 6;
            var angleDifference = Math.Abs(hourAngle - minuteAngle);
            var smallestAngle = Math.Min(angleDifference, 360 - angleDifference);

            // Log calculation details
            _logger.LogInformation(
                "Calculated smallest angle ({DateTime}): {SmallestAngle}",
                dateTime,
                smallestAngle
            );

            // Return the response
            return smallestAngle;
        }
    }
}

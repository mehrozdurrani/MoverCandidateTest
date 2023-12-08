
using MoverCandidateTest.Services.Errors;

namespace MoverCandidateTest.Services.WatchHands
{
    public class CalculateLeastAngleService : ICalculateLeastAngleService
    {
        public double CalculateLeastAngle(DateTime dateTime)
        {
            if (dateTime.Hour is > 23 or < 0 || dateTime.Minute is > 60 or < 0)
            {
                throw new InvalidTimeException();
            }

            // Get the hour and minute from the request
            var hour = dateTime.Hour % 12;
            var minute = dateTime.Minute;

            // Calculate the smallest angle between the hour and minute hand
            var hourAngle = hour * 30 + minute * 0.5;
            var minuteAngle = minute * 6;
            var angleDifference = Math.Abs(hourAngle - minuteAngle);
            var smallestAngle = Math.Min(angleDifference, 360 - angleDifference);

            // Return the response
            return smallestAngle;
        }
    }
}

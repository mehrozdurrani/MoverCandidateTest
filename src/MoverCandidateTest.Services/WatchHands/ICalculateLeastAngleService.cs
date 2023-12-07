
using MoverCandidateTest.Contracts.WatchHands;

namespace MoverCandidateTest.Services.WatchHands
{
    public interface ICalculateLeastAngleService
    {
        public CalculateLeastAngleResponse CalculateLeastAngle(DateTime dateTime);
    }
}
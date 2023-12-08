using System.ComponentModel.DataAnnotations;

namespace MoverCandidateTest.Contracts.WatchHands
{
    public record CalculateLeastAngleRequest
    {
        [Required(ErrorMessage = "DateTime is required")]
        [DataType(DataType.DateTime, ErrorMessage = "DateTime must be in a valid date and time format")]
        public DateTime DateTime { get; init; }
    }
}
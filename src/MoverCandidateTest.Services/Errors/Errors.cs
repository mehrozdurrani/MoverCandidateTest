
using System.Net;

namespace MoverCandidateTest.Services.Errors
{
    public class InvalidTimeException : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Invalid Time, Please request with a valid time.";
    }
}
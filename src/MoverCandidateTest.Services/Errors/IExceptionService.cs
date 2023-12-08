using System.Net;

namespace MoverCandidateTest.Services.Errors
{
    public interface IExceptionService
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
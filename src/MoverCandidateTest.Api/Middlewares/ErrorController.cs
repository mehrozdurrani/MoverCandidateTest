using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoverCandidateTest.Api.Controllers;
using MoverCandidateTest.Services.Errors;

namespace MoverCandidateTest.Api.Middlewares
{
    public class ErrorController : ApiController
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            switch (exception)
            {
                case IExceptionService serviceException:
                    return Problem(
                        statusCode: (int?)serviceException.StatusCode,
                        detail: serviceException.ErrorMessage
                    );
                default:
                    return Problem(
                        StatusCodes.Status500InternalServerError.ToString(),
                        $"Unknown Error: {exception?.Message.ToString()}"
                    );
            }
        }
    }
}
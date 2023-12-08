using System;

using System.Net;

namespace MoverCandidateTest.Services.Errors
{
    public class InvalidQuantityException : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Invalid Quantity, Please request with a valid quantity.";
    }

    public class InventoryItemNotFoundException : Exception, IExceptionService
    {
        string Sku { get; }

        public InventoryItemNotFoundException(string sku)
        {
            Sku = sku;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.NoContent;
        public string ErrorMessage => string.Empty;
    }

    public class EmptyInventoryListException : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NoContent;
        public string ErrorMessage => string.Empty;
    }
}

using System;

using System.Net;

namespace MoverCandidateTest.Services.Errors
{
    public class InvalidTimeException : Exception, IExceptionService
    {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public string ErrorMessage => "Invalid Time, Please request with a valid time.";
    }
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
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public string ErrorMessage => $"Inventory Item of SKU: {Sku} Not Found.";
    }
}
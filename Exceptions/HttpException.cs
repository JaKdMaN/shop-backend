using System;
namespace shop_backend.Exceptions
{
    public class HttpException: Exception
    {
        public string errorMessage {  get; set; }
        public int StatusCode { get; set; }

        public HttpException(string message, int statusCode) : base(message)
        {
            errorMessage = message;
            StatusCode = statusCode;
        } 
    }
}

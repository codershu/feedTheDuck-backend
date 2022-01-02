using System;
namespace feedTheDuck.Models
{
    public class Response<T>
    {
        public Response()
        {
        }

        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T Result { get; set; }

        public Response(string message, bool isSuccess = true)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public static Response<T> Ok(T result, string message)
        {
            return new Response<T>()
            {
                Result = result,
                Message = message,
                IsSuccess = true
            };
        }

        public static Response<T> Error(string message)
        {
            return new Response<T>()
            {
                Message = message,
                IsSuccess = false
            };
        }
    }
}

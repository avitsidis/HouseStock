using System;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class Response<TData>
    {
        public static Response<TData> EmptyResponse = Success(default(TData));
        public TData Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFail => !IsSuccess;
        public Error Error { get; private set; }


        public static Response<TData> Success(TData data)
        {
            return new Response<TData>() { Data = data , IsSuccess = true, Error = Error.NoError };
        }

        public static Response<TData> Fail(string code, Exception e)
        {
            return new Response<TData>() { IsSuccess = false, Error = new Error(code,e.Message,e) };
        }
    }

    public class Error
    {
        public static Error NoError = new Error("OK", "ok");
        public Error(string code, string message, Exception e = null)
        {
            ErrorCode = code;
            Message = message;
            InnerException = e;
        }
        public string ErrorCode { get; }
        public string Message { get;}
        public Exception InnerException { get; }
    }
}

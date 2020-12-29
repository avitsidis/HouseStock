using System.Collections.Generic;

namespace HouseStock.Presentation.Blazor.Shared
{
    public class Response<TData>
    {
        public TData Data { get; private set; }
        public bool IsSucess { get; private set; }
        public List<Error> Errors { get; private set; }

        private Response()
        {
            Errors = new List<Error>();
        }

        public static Response<TData> Success(TData data)
        {
            return new Response<TData>() { Data = data , IsSucess = true};
        }
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}

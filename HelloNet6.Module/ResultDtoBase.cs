using System.Net;

namespace HelloNet6.Module
{
    public record ResultDtoBase<T>
    {
        public HttpStatusCode Code { get; init; }

        public bool Result { get; init; }

        public string? Msg { get; init; }

        public T Data { get; init; } = default!;

        public static ResultDtoBase<T> CreateErrorResult(string msg, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            return new ResultDtoBase<T>
            {
                Code = code,
                Result = false,
                Msg = msg
            };
        }

        public static ResultDtoBase<T> CreateSucceedResult(T data, string? msg = null)
        {
            return new ResultDtoBase<T>
            {
                Code = HttpStatusCode.OK,
                Result = true,
                Msg = msg,
                Data = data
            };
        }
    }
}
using System.Net;

namespace HelloNet6.Module
{
    public record ResultVoBase<T>
    {
        public HttpStatusCode Code { get; init; }

        public bool Result { get; init; }

        public string? Msg { get; init; }

        public T Data { get; init; } = default!;

        public static ResultVoBase<T> CreateErrorResult(string msg, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            return new ResultVoBase<T>
            {
                Code = code,
                Result = false,
                Msg = msg
            };
        }

        public static ResultVoBase<T> CreateSucceedResult(T data, string? msg = null)
        {
            return new ResultVoBase<T>
            {
                Code = HttpStatusCode.OK,
                Result = true,
                Msg = msg,
                Data = data
            };
        }
    }
}
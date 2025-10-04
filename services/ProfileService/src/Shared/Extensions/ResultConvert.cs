using FluentResults;

namespace Shared.Extensions
{
    public static class ResultConvert
    {
        public static Result<TOut> Convert<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> mapper)
        {
            return result.IsSuccess
                ? Result.Ok(mapper(result.Value))
                : Result.Fail<TOut>(result.Errors);
        }
    }
}
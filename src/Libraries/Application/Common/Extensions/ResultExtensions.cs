namespace BuildingMaterialAccounting.Application.Common.Extensions
{
    public static class ResultExtensions
    {
        public static Result WithMessage(this Result result, string message)
        {
            result.Messages.Add(message);
            return result;
        }
        public static Result<TData> WithMessage<TData>(this Result<TData> result, string message)
        {
            result.Messages.Add(message);
            return result;
        }
    }
}
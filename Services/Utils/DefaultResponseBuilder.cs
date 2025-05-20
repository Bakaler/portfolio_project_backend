public class DefaultResponseBuilder : IResponseBuilder
{
    public StandardResponse<T> CreateSuccessResponse<T>(T result)
        => new StandardResponse<T>(200, result, new List<StandardError>());

    public StandardResponse<T> CreateErrorResponse<T>(List<StandardError> errors, int status = 500)
        => new StandardResponse<T>(status, default, errors);

    public StandardError CreateError(ErrorCode code, string message, object data)
        => new StandardError(code, message, data);
}

public interface IResponseBuilder
{
    StandardResponse<T> CreateSuccessResponse<T>(T result);
    StandardResponse<T> CreateErrorResponse<T>(List<StandardError> errors, int status = 500);
    StandardError CreateError(ErrorCode code, string message, object data);
}
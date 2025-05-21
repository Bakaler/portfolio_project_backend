/// <summary>
/// Defines methods for building standardized API responses and errors.
/// </summary>
public interface IResponseBuilder
{
    /// <summary>
    /// Creates a successful standardized response wrapping the given result.
    /// </summary>
    /// <typeparam name="T">The type of the response result.</typeparam>
    /// <param name="result">The result object to include in the response.</param>
    /// <returns>A <see cref="StandardResponse{T}"/> representing a successful operation.</returns>
    StandardResponse<T> CreateSuccessResponse<T>(T result);


    /// <summary>
    /// Creates an error standardized response with a list of errors and an optional HTTP status code.
    /// </summary>
    /// <typeparam name="T">The type of the response result (usually default/null for errors).</typeparam>
    /// <param name="errors">A list of <see cref="StandardError"/> representing the errors.</param>
    /// <param name="status">The HTTP status code for the error response. Defaults to 500 (Internal Server Error).</param>
    /// <returns>A <see cref="StandardResponse{T}"/> representing a failed operation with errors.</returns>    
    StandardResponse<T> CreateErrorResponse<T>(List<StandardError> errors, int status = 500);

    /// <summary>
    /// Creates a standardized error object.
    /// </summary>
    /// <param name="code">The error code identifying the type/category of error.</param>
    /// <param name="message">A human-readable message describing the error.</param>
    /// <param name="data">Optional additional data related to the error.</param>
    /// <returns>A <see cref="StandardError"/> instance representing the error.</returns>    
    StandardError CreateError(ErrorCode code, string message, object data);
}
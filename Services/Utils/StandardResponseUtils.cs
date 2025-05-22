using System;
using System.Collections.Generic;

public static class StandardResponseUtils
{
    /// <summary>
    /// Creates a StandardResponse representing a successful result.
    /// </summary>
    public static StandardResponse<T> CreateSuccessResponse<T>(T result)
    {
        return new StandardResponse<T>(200, result, new List<StandardError>());
    }

    /// <summary>
    /// Creates a StandardError from given parameters.
    /// </summary>
    public static StandardError CreateStandardError(ErrorCode code, string message, object data)
    {
        return new StandardError(code, message, data);
    }

    /// <summary>
    /// Creates a StandardResponse representing a failure with one or more errors.
    /// </summary>
    public static StandardResponse<T> CreateErrorResponse<T>(List<StandardError> errors, int status = 500)
    {
        return new StandardResponse<T>(status, default, errors);
    }

    /// <summary>
    /// Chains the next function if the current response is successful.
    /// Adds an error if chaining fails.
    /// </summary>
    public static StandardResponse<R> NextResultHandler<T, R>(
        StandardResponse<T> response,
        Func<T, StandardResponse<R>> next,
        StandardError addedError = null)
    {
        if (!response.IsSuccess || response.result == null)
        {
            var combinedErrors = new List<StandardError>(response.errors);
            if (addedError != null)
            {
                combinedErrors.Add(addedError);
            }
            return CreateErrorResponse<R>(combinedErrors, response.status);
        }

        return next(response.result);
    }
}
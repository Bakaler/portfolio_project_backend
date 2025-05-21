/// <summary>
/// Represents a standardized error with a code, message, and optional data.
/// </summary>
public class StandardError
{
  /// <summary>
  /// The integer error code identifying the specific error type.
  /// </summary>
  public int Code { get; }

  /// <summary>
  /// A human-readable description of the error.
  /// </summary>
  public string Message { get; }

  /// <summary>
  /// Additional data associated with the error, if applicable.
  /// </summary>
  public object Data { get; }
  
  /// <summary>
  /// Initializes a new instance of the <see cref="StandardError"/> class using the provided error code, message, and data.
  /// </summary>
  /// <param name="code">The <see cref="ErrorCode"/> enum representing the error category.</param>
  /// <param name="message">A description of the error.</param>
  /// <param name="data">Any additional context or data associated with the error.</param>
  public StandardError(ErrorCode code, string message, object data)
  {
    Code = code.Code;
    Message = message;
    Data = data;
  }
}

/// <summary>
/// A generic wrapper for standardized responses, including success results or error details.
/// </summary>
/// <typeparam name="T">The type of the result payload.</typeparam>
public class StandardResponse<T>
{
  /// <summary>
  /// The result of the operation. Will be <c>null</c> if the response indicates an error.
  /// </summary>
  public T Result { get; }

  /// <summary>
  /// A list of standardized errors encountered during the operation.
  /// </summary>
  public List<StandardError> Errors { get; }

  /// <summary>
  /// The HTTP status code associated with the response.
  /// </summary>
  public int Status { get; }

  /// <summary>
  /// Indicates whether the response was successful.
  /// True if status is 200 and there are no errors.
  /// </summary>
  public bool IsSuccess => Status == 200 && Errors.Count == 0;


  /// <summary>
  /// Initializes a new instance of the <see cref="StandardResponse{T}"/> class.
  /// </summary>
  /// <param name="status">The HTTP status code for the response.</param>
  /// <param name="result">The result payload.</param>
  /// <param name="errors">A list of any errors encountered during execution.</param>
  public StandardResponse(int status, T result, List<StandardError> errors)
  {
    Status = status;
    Result = result;
    Errors = errors;
  }
}
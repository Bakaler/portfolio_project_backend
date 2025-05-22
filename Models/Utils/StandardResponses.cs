/// <summary>
/// Represents a standardized error with a code, message, and optional data.
/// </summary>
public class StandardError
{
  /// <summary>
  /// The integer error code identifying the specific error type.
  /// </summary>
  public int code { get; }

  /// <summary>
  /// A human-readable description of the error.
  /// </summary>
  public string message { get; }

  /// <summary>
  /// Additional data associated with the error, if applicable.
  /// </summary>
  public object data { get; }
  
  /// <summary>
  /// Initializes a new instance of the <see cref="StandardError"/> class using the provided error code, message, and data.
  /// </summary>
  /// <param name="_code">The <see cref="ErrorCode"/> enum representing the error category.</param>
  /// <param name="_message">A description of the error.</param>
  /// <param name="_data">Any additional context or data associated with the error.</param>
  public StandardError(ErrorCode _code, string _message, object _data)
  {
    code = _code.Code;
    message = _message;
    data = _data;
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
  public T result { get; }

  /// <summary>
  /// A list of standardized errors encountered during the operation.
  /// </summary>
  public List<StandardError> errors { get; }

  /// <summary>
  /// The HTTP status code associated with the response.
  /// </summary>
  public int status { get; }

  /// <summary>
  /// Indicates whether the response was successful.
  /// True if status is 200 and there are no errors.
  /// </summary>
  public bool IsSuccess => status == 200 && errors.Count == 0;


  /// <summary>
  /// Initializes a new instance of the <see cref="StandardResponse{T}"/> class.
  /// </summary>
  /// <param name="status">The HTTP status code for the response.</param>
  /// <param name="result">The result payload.</param>
  /// <param name="errors">A list of any errors encountered during execution.</param>
  public StandardResponse(int _status, T _result, List<StandardError> _errors)
  {
    status = _status;
    result = _result;
    errors = _errors;
  }
}
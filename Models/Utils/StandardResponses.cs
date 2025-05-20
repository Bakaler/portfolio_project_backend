public class StandardError
{
  public int Code { get; }
  public string Message { get; }
  public object Data { get; }

  public StandardError(ErrorCode code, string message, object data)
  {
    Code = code.Code;
    Message = message;
    Data = data;
  }
}

public class StandardResponse<T>
{
    /**
   * Function Result. Null if an error occurs.
   */
    public T Result { get; }
    
    /**
   * List of errors generated during function execution
   */
    public List<StandardError> Errors { get; }
    
    /**
   * HTTP Status code associated with outcome.
   * Generally, 200 if successful, otherwise an appropriate HTTP error status.
   */
    public int Status { get; }


    public bool IsSuccess => Status == 200 && Errors.Count == 0;

    public StandardResponse(int status, T result, List<StandardError> errors)
    {
        Status = status;
        Result = result;
        Errors = errors;
    }
}
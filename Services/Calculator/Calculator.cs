

using PortfolioBackend.Models.Calculator;

public class CalculatorService
{
  private readonly IResponseBuilder _responseBuilder;

  public CalculatorService(IResponseBuilder responseBuilder)
  {
    _responseBuilder = responseBuilder;
  }

  public StandardResponse<CalculateResponse> Evaluate(string userInput, string equationLine, string commandLine)
  {
    if (isOperand(userInput).result)
    {
      if (isOperand(commandLine).result)
      {
        commandLine += userInput;
      }
      else if (commandLine.Length == 0)
      {
        commandLine = userInput;
      }
      else if (isOperator(commandLine).result)
      {
        equationLine += commandLine;
        commandLine = userInput;
      }
    }
    else if (isOperator(userInput).result)
    {
      if (isOperand(commandLine).result)
      {
        equationLine += commandLine;
        commandLine = userInput;
      }
      else if (isOperator(commandLine).result)
      {
        commandLine = userInput;
      }
    }

    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = equationLine,
      command_line = commandLine,
      user_input = userInput
    });
  }

  public StandardResponse<bool> isOperand(string s) => _responseBuilder.CreateSuccessResponse(int.TryParse(s, out _));
  public StandardResponse<bool> isOperator(string s) => _responseBuilder.CreateSuccessResponse(s == "+" || s == "-" || s == "*" || s == "/");
}

// public class CalculatorService
// {
//     public SendToBackendResult Evaluate(string userInput, string equationLine, string commandLine)
//     {
//         // For now, just process simple expressions like "1 + 1"
//         try
//         {
//             string trimmed = userInput.Trim();
//             var result = EvaluateExpression(trimmed); // see below

//             return new SendToBackendResult
//             {
//                 EquationLine = $"{equationLine} {userInput} = {result}",
//                 CommandLine = commandLine,
//                 Output = result.ToString()
//             };
//         }
//         catch (Exception ex)
//         {
//             throw new InvalidOperationException("Invalid input: " + ex.Message);
//         }
//     }

//     private double EvaluateExpression(string input)
//     {
//         // Basic implementation — for MVP, you could use DataTable
//         var table = new System.Data.DataTable();
//         return Convert.ToDouble(table.Compute(input, string.Empty));
//     }
// }
using PortfolioBackend.Models.Calculator;
using System.Text.RegularExpressions;

public class InputHandler : IInputHandler
{
    private readonly IResponseBuilder _responseBuilder;

    public InputHandler(IResponseBuilder responseBuilder)
    {
        _responseBuilder = responseBuilder;
    }

    public StandardResponse<string?> GetTrailingInput(string equationLine)
    {
        if (!string.IsNullOrEmpty(equationLine))
        {
            var match = Regex.Match(equationLine, @"\S*\s?$");
            if (match.Success)
            {
                var result = match.Value.Trim();
                return _responseBuilder.CreateSuccessResponse(string.IsNullOrEmpty(result) ? null : result);
            }
        }

        return _responseBuilder.CreateSuccessResponse<string?>(null);
    }

    public StandardResponse<bool> Inspect(string r, string userInput)
    {
      // Null or empty check
      if (string.IsNullOrEmpty(userInput))
        return _responseBuilder.CreateSuccessResponse(false);

      return _responseBuilder.CreateSuccessResponse(Regex.IsMatch(userInput, r));
    }

  public StandardResponse<CalculateResponse> UpdateLines(string commandType, string userInput, string equationLine, string commandLine)
  {
    if (userInput == "=")
    {

      // TEMP TEMP TEMP
      // Solve()
      return _responseBuilder.CreateSuccessResponse(new CalculateResponse
      {
        equation_line = equationLine,
        command_line = commandLine,
        user_input = userInput
      });
    }

    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = equationLine,
      command_line = commandLine,
      user_input = userInput
    });


  }

    public StandardResponse<CalculateResponse> HandleDelete(string userInput, string equationLine, string commandLine)
    {
      if (commandLine == "error")
      {
        equationLine = "";
        commandLine = "";
      }
      if (commandLine.Length >= 1 && equationLine.Length >= 1)
      {
        if (equationLine[^1] == commandLine[^1])
        {
          equationLine = equationLine.Substring(0, equationLine.Length - 1);
        }
        if (equationLine.Length >= 2 && equationLine[^1] == '.' && commandLine == "0")
        {
          equationLine = equationLine.Substring(0, equationLine.Length - 2);
        }
        commandLine = commandLine.Substring(0, commandLine.Length - 1);
      }
      if (commandLine == "")
      {
        commandLine = "0";
      }
      return _responseBuilder.CreateSuccessResponse(new CalculateResponse
      {
        equation_line = equationLine,
        command_line = commandLine,
        user_input = userInput
      });

    }
  
}







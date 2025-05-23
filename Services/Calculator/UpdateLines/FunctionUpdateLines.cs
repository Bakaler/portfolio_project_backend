using PortfolioBackend.Models.Calculator;
// using PortfolioBackend.Interfaces.Services.Calculator.IUpdateLines;

public class FunctionUpdateLines : IFunctionUpdateLines
{
  private readonly IResponseBuilder _responseBuilder;

  public FunctionUpdateLines(IResponseBuilder responseBuilder)
  {
    _responseBuilder = responseBuilder;
  }

  public StandardResponse<CalculateResponse> UpdateLines(string userInput, string equationLine, string commandLine)
  {
    Console.WriteLine($"FunctionUpdateLines.UpdateLines({userInput}, {equationLine}, {commandLine})");

    var updatedCommandLine = commandLine;
    var updatedEquationLine = equationLine;

    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = updatedEquationLine,
      command_line = updatedCommandLine,
      user_input = userInput
    });
  }
}

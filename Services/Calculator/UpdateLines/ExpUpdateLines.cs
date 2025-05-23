using PortfolioBackend.Models.Calculator;
// using PortfolioBackend.Interfaces.Services.Calculator.IUpdateLines;

public class ExpUpdateLines : IExpUpdateLines
{
  private readonly IResponseBuilder _responseBuilder;

  public ExpUpdateLines(IResponseBuilder responseBuilder)
  {
    _responseBuilder = responseBuilder;
  }

  public StandardResponse<CalculateResponse> UpdateLines(string userInput, string equationLine, string commandLine)
  {
    Console.WriteLine($"ExpUpdateLines.UpdateLines({userInput}, {equationLine}, {commandLine})");

    var updatedCommandLine = userInput;
    var updatedEquationLine = equationLine + userInput;

    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = updatedEquationLine,
      command_line = updatedCommandLine,
      user_input = userInput
    });
  }
}

using PortfolioBackend.Models.Calculator;
// using PortfolioBackend.Interfaces.Services.Calculator.IUpdateLines;

public class FactorUpdateLines : IFactorUpdateLines
{
  private readonly IResponseBuilder _responseBuilder;

  public FactorUpdateLines(IResponseBuilder responseBuilder)
  {
    _responseBuilder = responseBuilder;
  }

  public StandardResponse<CalculateResponse> UpdateLines(string userInput, string equationLine, string commandLine)
  {
    Console.WriteLine($"FactorUpdateLines.UpdateLines({userInput}, {equationLine}, {commandLine})");

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

using PortfolioBackend.Models.Calculator;
// using PortfolioBackend.Interfaces.Services.Calculator.IUpdateLines;

public class DigitUpdateLines : IDigitUpdateLines
{
  private readonly IResponseBuilder _responseBuilder;

  public DigitUpdateLines(IResponseBuilder responseBuilder)
  {
    _responseBuilder = responseBuilder;
  }

  public StandardResponse<CalculateResponse> UpdateLines(string userInput, string equationLine, string commandLine)
  {
    Console.WriteLine($"DigitUpdateLines.UpdateLines({userInput}, {equationLine}, {commandLine})");
    var updatedCommandLine = commandLine == "0" ? userInput : commandLine + userInput;
    var updatedEquationLine = equationLine + userInput;

    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = updatedEquationLine,
      command_line = updatedCommandLine,
      user_input = userInput
    });
  }
}

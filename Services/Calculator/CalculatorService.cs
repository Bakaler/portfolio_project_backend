

using PortfolioBackend.Models.Calculator;
using System.Text.RegularExpressions;

public class CalculatorService
{
    private readonly IExpressionParser _expressionParser;
    private readonly IResponseBuilder _responseBuilder;
    private readonly IInputHandler _inputHandler;

    public CalculatorService(
        IExpressionParser expressionParser,
        IInputHandler inputHandler,
        IResponseBuilder responseBuilder)
    {
        _expressionParser = expressionParser;
        _responseBuilder = responseBuilder;
        _inputHandler = inputHandler;
    }

    public StandardResponse<CalculateResponse> Evaluate(string userInput, string equationLine, string commandLine)
    {
        if (userInput == "Delete")
            return _inputHandler.HandleDelete(userInput, equationLine, commandLine);

        var trailingInput = _inputHandler.GetTrailingInput(equationLine).result;
        return _expressionParser.Parse(userInput, equationLine, commandLine, trailingInput);
    }
}
using PortfolioBackend.Models.Calculator;

public interface IExpressionParser
{
    StandardResponse<CalculateResponse> Parse(string userInput, string equationLine, string commandLine, string? trailingInput);
}

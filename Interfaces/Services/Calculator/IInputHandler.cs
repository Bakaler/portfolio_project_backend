using PortfolioBackend.Models.Calculator;

public interface IInputHandler
{
    StandardResponse<string?> GetTrailingInput(string equationLine);
    StandardResponse<bool> Inspect(string pattern, string userInput);
    StandardResponse<CalculateResponse> UpdateLines(string commandType, string userInput, string equationLine, string commandLine);
    StandardResponse<CalculateResponse> HandleDelete(string userInput, string equationLine, string commandLine);
}

using PortfolioBackend.Models.Calculator;

public interface IUpdateLines
{
  // bool Matches(string input); // Returns true if this class handles the input
  StandardResponse<CalculateResponse> UpdateLines(string userInput, string equationLine, string commandLine);
}

public interface IExpUpdateLines : IUpdateLines { }
public interface ITermUpdateLines : IUpdateLines { }
public interface IFactorUpdateLines : IUpdateLines { }
public interface IPowerUpdateLines : IUpdateLines { }
public interface IFunctionUpdateLines : IUpdateLines { }
public interface IDigitUpdateLines : IUpdateLines { }
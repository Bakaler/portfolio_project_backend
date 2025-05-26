using PortfolioBackend.Models.Calculator;

public class ExpressionParser : IExpressionParser
{
  private readonly IResponseBuilder _responseBuilder;
  private readonly IInputHandler _inputHandler;
  private readonly IDigitUpdateLines _digitUpdateLines;
  private readonly IFunctionUpdateLines _functionUpdateLines;
  private readonly IPowerUpdateLines _powerUpdateLines;
  private readonly IFactorUpdateLines _factorUpdateLines;
  private readonly ITermUpdateLines _termUpdateLines;
  private readonly IExpUpdateLines _expUpdateLines;


  private readonly HashSet<string> _operands = new() { "+", "-", "*", "**", "/", "%", "//" };

  public ExpressionParser(
      IResponseBuilder responseBuilder,
      IInputHandler inputHandler,
      IDigitUpdateLines digitUpdateLines,
      IFunctionUpdateLines functionUpdateLines,
      IPowerUpdateLines powerUpdateLines,
      IFactorUpdateLines factorUpdateLines,
      ITermUpdateLines termUpdateLines,
      IExpUpdateLines expUpdateLines)
  {
    _responseBuilder = responseBuilder;
    _inputHandler = inputHandler;

    _digitUpdateLines = digitUpdateLines;
    _functionUpdateLines = functionUpdateLines;
    _powerUpdateLines = powerUpdateLines;
    _factorUpdateLines = factorUpdateLines;
    _termUpdateLines = termUpdateLines;
    _expUpdateLines = expUpdateLines;
  }

  public StandardResponse<CalculateResponse> Parse(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    // Old `Exp` logic
    if (userInput == "=")
    {
      return _inputHandler.UpdateLines("Solve", userInput, equationLine, commandLine);
    }

    // Move the rest of `Exp`, `Term`, `Factor`, etc. logic here
    // You could use a method for each grammar rule like before
    return Exp(userInput, equationLine, commandLine, trailingInput);
  }

  // _exp ::=
  // '='
  // exp '+' term
  // exp '-' term
  // term
  private StandardResponse<CalculateResponse> Exp(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    Console.WriteLine($"Exp({userInput}, {equationLine}, {commandLine}, {trailingInput})");
    if (userInput == "=")
    {
      return _inputHandler.UpdateLines("Solve", userInput, equationLine, commandLine);
    }
    else
    {
      if (_inputHandler.Inspect(@"[\-\+]", userInput).result)
      {
        if (trailingInput == null || trailingInput[^1] == '(')
        {
          return _responseBuilder.CreateSuccessResponse(new CalculateResponse
          {
            equation_line = equationLine,
            command_line = commandLine,
            user_input = userInput
          });
        }
        else if (_operands.Contains(trailingInput))
        {
          equationLine = equationLine.Substring(0, equationLine.Length - trailingInput.Length - 2);
          return _expUpdateLines.UpdateLines(' ' + userInput + ' ', equationLine, commandLine);
        }
        else if (trailingInput[^1] == ')')
        {
          return _expUpdateLines.UpdateLines(' ' + userInput + ' ', equationLine, commandLine);
        }
        else if (Exp(trailingInput, equationLine, commandLine, trailingInput).result != null || Exp($"{trailingInput[^1]}", equationLine, commandLine, trailingInput).result != null)
        {
          return _expUpdateLines.UpdateLines(' ' + userInput + ' ', equationLine, commandLine);
        }
        else
        {
          return Term(userInput, equationLine, commandLine, trailingInput);
        }
      }
      else
      {
        return Term(userInput, equationLine, commandLine, trailingInput);
      }

    }
  }

  // _term ::=
  //     term '*' factor
  //     term '/' factor
  //     term '//' factor
  //     term '%' factor
  //     factor

  // TODO TODO TODO TODO TODO TODO TODO TODO
  private StandardResponse<CalculateResponse> Term(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    // Is user input is in *, /, //, %
    if (_inputHandler.Inspect(@"[\*/%]", userInput).result)
    {
      // if trailing input is null
      if (trailingInput == null)
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (trailingInput[^1] == ')')
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (_inputHandler.Inspect(@"[\-\+]", userInput).result)
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (trailingInput[^1] == ')')
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (Term(trailingInput, equationLine, commandLine, trailingInput).result != null || Term($"{trailingInput[^1]}", equationLine, commandLine, trailingInput).result != null)
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
    }
    return Factor(userInput, equationLine, commandLine, trailingInput);
  }
  private StandardResponse<CalculateResponse> Factor(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    // TODO TODO TODO TODO TODO TODO TODO TODO
    if (userInput == "(")
    {
      if (trailingInput == "=")
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (trailingInput == null || trailingInput[^1] == '(')
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      if (trailingInput[^1] == ')' || Function(trailingInput, equationLine, commandLine, trailingInput).result != null)
      {
        // EQUATIONLINEFLAG??
        if (false)
        {
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
      // if trailing input is an operand
      if (_inputHandler.Inspect(@"[\-\+]", trailingInput).result)
      {
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }

    }
    else if (userInput == ")")
    {
      if (get_paranBalance(equationLine).result > 0)
      {
        if (trailingInput != null && trailingInput[^1] == '(')
        {
          return _responseBuilder.CreateSuccessResponse(new CalculateResponse
          {
            equation_line = equationLine,
            command_line = commandLine,
            user_input = userInput
          });
        }
        if (trailingInput != null && _inputHandler.Inspect(@"[\-\+]", trailingInput).result)
        {
          return _responseBuilder.CreateSuccessResponse(new CalculateResponse
          {
            equation_line = equationLine,
            command_line = commandLine,
            user_input = userInput
          });
        }
      }
      return _responseBuilder.CreateSuccessResponse(new CalculateResponse
      {
        equation_line = equationLine,
        command_line = commandLine,
        user_input = userInput
      });
    }

    return Power(userInput, equationLine, commandLine, trailingInput);
  }
  private StandardResponse<CalculateResponse> Power(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    return Function(userInput, equationLine, commandLine, trailingInput);
  }
  private StandardResponse<CalculateResponse> Function(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    return Digit(userInput, equationLine, commandLine, trailingInput);
  }

  // _digit ::=
  //     int '.' int
  //     int
  private StandardResponse<CalculateResponse> Digit(string userInput, string equationLine, string commandLine, string? trailingInput)
  {
    Console.WriteLine($"Digit({userInput}, {equationLine}, {commandLine}, {trailingInput})");

    // TODO Verify that trailingInput cant ever be null here 
    if (trailingInput != null && trailingInput[^1] == ')')
    {
      Console.WriteLine("1");
      return _responseBuilder.CreateSuccessResponse(new CalculateResponse
      {
        equation_line = equationLine,
        command_line = commandLine,
        user_input = userInput
      });
    }
    else if (_inputHandler.Inspect(@"^\d+", userInput).result)
    {
      Console.WriteLine("2");
      return _digitUpdateLines.UpdateLines(userInput, equationLine, commandLine);
    }
    else if (_inputHandler.Inspect(@"\.", userInput).result)
    {
      if (_inputHandler.Inspect(@"\d+\.\d*", trailingInput).result)
      {
        Console.WriteLine("3");
        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }
      else if (_inputHandler.Inspect(@"\d+", trailingInput).result)
      {
        Console.WriteLine("4");

        return _digitUpdateLines.UpdateLines(userInput, equationLine, commandLine);
      }
      else if (trailingInput == null || _inputHandler.Inspect(@"\s?\S*$", trailingInput).result)
      {
        Console.WriteLine("5");

        return _inputHandler.UpdateLines("SoloDec", userInput, equationLine, commandLine);
      }
      else
      {
        Console.WriteLine("6");

        return _responseBuilder.CreateSuccessResponse(new CalculateResponse
        {
          equation_line = equationLine,
          command_line = commandLine,
          user_input = userInput
        });
      }



    }
    else
    {
      Console.WriteLine("7");

      return _responseBuilder.CreateSuccessResponse(new CalculateResponse
      {
        equation_line = equationLine,
        command_line = commandLine,
        user_input = userInput
      });
    }
  }

  public StandardResponse<CalculateResponse> Solve(string userInput, string equationLine, string commandLine)
  {
    return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    {
      equation_line = equationLine,
      command_line = commandLine,
      user_input = userInput
    });
  }

  private StandardResponse<CalculateResponse> HandleDelete(string userInput, string equationLine, string commandLine)
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

  public StandardResponse<int> get_paranBalance(string equationLine)
  {
    int count = 0;
    for (int i = 0; i < equationLine.Length; i++)
    {
      if (equationLine[i] == '(')
      {
        count++;
      }
      else if (equationLine[i] == ')')
      {
        count--;
      }
    }
    return _responseBuilder.CreateSuccessResponse(count);
  }
}

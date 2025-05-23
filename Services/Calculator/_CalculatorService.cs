

// using PortfolioBackend.Models.Calculator;
// using System.Text.RegularExpressions;

// public class _CalculatorService
// {
//   private readonly IResponseBuilder _responseBuilder;
//   private readonly HashSet<string> _operands = new() { "+", "-", "*", "**", "/", "%", "//" }; 

//   public _CalculatorService(IResponseBuilder responseBuilder)
//   {
//     _responseBuilder = responseBuilder;
//   }

//   public StandardResponse<CalculateResponse> Evaluate(string userInput, string equationLine, string commandLine)
//   {

//     if (userInput == "Delete")
//     {
//       return HandleDelete(userInput, equationLine, commandLine);
//     }
//     else
//     {
//       var trailingInput = GetTrailingInput(equationLine).result;

//       return Exp(userInput, equationLine, commandLine, trailingInput);
//     }
//   }

//   public StandardResponse<CalculateResponse> Parse(string userInput, string equationLine, string commandLine)
//   {
//     if (commandLine == "error")
//     {
//       equationLine = "";
//       commandLine = "";
//     }

//     // TEMP
//     return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//     {
//       equation_line = equationLine,
//       command_line = commandLine,
//       user_input = userInput
//     }); 
//   }

//   public StandardResponse<CalculateResponse> UpdateLines(string commandType, string userInput, string equationLine, string commandLine)
//   {
//     if (userInput == "=")
//     {

//       // TEMP TEMP TEMP
//       // Solve()
//       return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//       {
//         equation_line = equationLine,
//         command_line = commandLine,
//         user_input = userInput
//       });
//     }

//     return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//     {
//       equation_line = equationLine,
//       command_line = commandLine,
//       user_input = userInput
//     });


//   }
  

  // _exp ::=
  //     '='
  //     exp '+' term
  //     exp '-' term
  //     term
  // public StandardResponse<CalculateResponse> Exp(string userInput, string equationLine, string commandLine, string? trailingInput)
  // {
    // Console.WriteLine($"Exp({userInput}, {equationLine}, {commandLine}, {trailingInput})");
    // if (userInput == "=")
    // {
    //   return UpdateLines("Solve", userInput, equationLine, commandLine);
    // }
    // else
    // {
    //   if (Inspect(@"[\-\+]", userInput).result)
    //   {
    //     if (trailingInput == null || trailingInput[^1] == '(')
    //     {
    //       return _responseBuilder.CreateSuccessResponse(new CalculateResponse
    //       {
    //         equation_line = equationLine,
    //         command_line = commandLine,
    //         user_input = userInput
    //       });
    //     }
    //     else if (_operands.Contains(trailingInput))
    //     {
    //       equationLine = equationLine.Substring(0, equationLine.Length - trailingInput.Length - 2);
    //       return UpdateLines("Exp", ' ' + userInput + ' ', equationLine, commandLine);
    //     }
    //     else if (trailingInput[^1] == ')')
    //     {
    //       return UpdateLines("Exp", ' ' + userInput + ' ', equationLine, commandLine);
    //     }
    //     else if (Exp(trailingInput, equationLine, commandLine, trailingInput).result != null || Exp($"{trailingInput[^1]}", equationLine, commandLine, trailingInput).result != null)
    //     {
    //       return UpdateLines("Exp", ' ' + userInput + ' ', equationLine, commandLine);
    //     }
    //     else
    //     {
    //       return Term(userInput, equationLine, commandLine, trailingInput);
    //     }
    //   }
    //   else
    //   {
    //     return Term(userInput, equationLine, commandLine, trailingInput);
    //   }

    // }
  // }

//   // _term ::=
//   //     term '*' factor
//   //     term '/' factor
//   //     term '//' factor
//   //     term '%' factor
//   //     factor
//   public StandardResponse<CalculateResponse> Term(string userInput, string equationLine, string commandLine, string? trailingInput)
//   {

//     return Factor(userInput, equationLine, commandLine, trailingInput);
//   }
//   public StandardResponse<CalculateResponse> Factor(string userInput, string equationLine, string commandLine, string? trailingInput)
//   {
//     return Power(userInput, equationLine, commandLine, trailingInput);
//   }
//   public StandardResponse<CalculateResponse> Power(string userInput, string equationLine, string commandLine, string? trailingInput)
//   {
//     return Function(userInput, equationLine, commandLine, trailingInput);
//   }
//   public StandardResponse<CalculateResponse> Function(string userInput, string equationLine, string commandLine, string? trailingInput)
//   {
//     return Digit(userInput, equationLine, commandLine, trailingInput);
//   }

//   // _digit ::=
//   //     int '.' int
//   //     int
//   public StandardResponse<CalculateResponse> Digit(string userInput, string equationLine, string commandLine, string? trailingInput)
//   {
//     Console.WriteLine($"Digit({userInput}, {equationLine}, {commandLine}, {trailingInput})");
    
//     // TODO Verify that trailingInput cant ever be null here 
//     if (trailingInput != null && trailingInput[^1] == ')')
//     {
//       return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//       {
//         equation_line = equationLine,
//         command_line = commandLine,
//         user_input = userInput
//       });
//     }
//     else if (Inspect(@"^\d+", userInput).result)
//     {
//       return UpdateLines("Digit", userInput, equationLine, commandLine);
//     }
//     else if (Inspect(@"\.", userInput).result)
//     {
//       if (Inspect(@"\d+\.\d*", trailingInput).result)
//       {
//         return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//         {
//           equation_line = equationLine,
//           command_line = commandLine,
//           user_input = userInput
//         });
//       }
//       else if (Inspect(@"\d+", trailingInput).result)
//       {
//         return UpdateLines("Digit", userInput, equationLine, commandLine);
//       }
//       else if (trailingInput == null || Inspect(@"\s?\S*$", trailingInput).result)
//       {
//         return UpdateLines("SoloDec", userInput, equationLine, commandLine);
//       }
//       else
//       {
//         return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//         {
//           equation_line = equationLine,
//           command_line = commandLine,
//           user_input = userInput
//         });
//       }



//     }
//     else
//     {
//       return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//       {
//         equation_line = equationLine,
//         command_line = commandLine,
//         user_input = userInput
//       });
//     }
//   }

//   public StandardResponse<CalculateResponse> Solve(string userInput, string equationLine, string commandLine)
//   {
//     return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//     {
//       equation_line = equationLine,
//       command_line = commandLine,
//       user_input = userInput
//     });
//   }
  

//   // public StandardResponse<string> GetTrailingInput(string equationLine)
//   // {
//   //     if (!string.IsNullOrEmpty(equationLine))
//   //     {
//   //         var match = Regex.Match(equationLine, @"\S*\s?$");
//   //         if (match.Success)
//   //         {
//   //             return _responseBuilder.CreateSuccessResponse(match.Value.Trim());
//   //         }
//   //     }
//   //     return _responseBuilder.CreateSuccessResponse(string.Empty);
//   // }

//   public StandardResponse<string?> GetTrailingInput(string equationLine)
//   {
//       if (!string.IsNullOrEmpty(equationLine))
//       {
//           var match = Regex.Match(equationLine, @"\S*\s?$");
//           if (match.Success)
//           {
//               var result = match.Value.Trim();
//               return _responseBuilder.CreateSuccessResponse(string.IsNullOrEmpty(result) ? null : result);
//           }
//       }

//       return _responseBuilder.CreateSuccessResponse<string?>(null);
//   }


//   public StandardResponse<bool> Inspect(string r, string userInput)
//   {
//     // Null or empty check
//     if (string.IsNullOrEmpty(userInput))
//       return _responseBuilder.CreateSuccessResponse(false);

//     return _responseBuilder.CreateSuccessResponse(Regex.IsMatch(userInput, r));
//   }

//   public StandardResponse<CalculateResponse> HandleDelete(string userInput, string equationLine, string commandLine)
//   {
//     if (commandLine == "error")
//     {
//       equationLine = "";
//       commandLine = "";
//     }
//     if (commandLine.Length >= 1 && equationLine.Length >= 1)
//     {
//       if (equationLine[^1] == commandLine[^1])
//       {
//         equationLine = equationLine.Substring(0, equationLine.Length - 1);
//       }
//       if (equationLine.Length >= 2 && equationLine[^1] == '.' && commandLine == "0")
//       {
//         equationLine = equationLine.Substring(0, equationLine.Length - 2);
//       }
//       commandLine = commandLine.Substring(0, commandLine.Length - 1);
//     }
//     if (commandLine == "")
//     {
//       commandLine = "0";
//     }
//     return _responseBuilder.CreateSuccessResponse(new CalculateResponse
//     {
//       equation_line = equationLine,
//       command_line = commandLine,
//       user_input = userInput
//     });

//   }
// }

// // public class CalculatorService
// // {
// //     public SendToBackendResult Evaluate(string userInput, string equationLine, string commandLine)
// //     {
// //         // For now, just process simple expressions like "1 + 1"
// //         try
// //         {
// //             string trimmed = userInput.Trim();
// //             var result = EvaluateExpression(trimmed); // see below

// //             return new SendToBackendResult
// //             {
// //                 EquationLine = $"{equationLine} {userInput} = {result}",
// //                 CommandLine = commandLine,
// //                 Output = result.ToString()
// //             };
// //         }
// //         catch (Exception ex)
// //         {
// //             throw new InvalidOperationException("Invalid input: " + ex.Message);
// //         }
// //     }

// //     private double EvaluateExpression(string input)
// //     {
// //         // Basic implementation — for MVP, you could use DataTable
// //         var table = new System.Data.DataTable();
// //         return Convert.ToDouble(table.Compute(input, string.Empty));
// //     }
// // }
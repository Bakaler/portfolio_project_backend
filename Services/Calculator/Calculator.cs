

// public class CalculatorService
// {
//     public SendToBackendResult Evaluate(string userInput, string equationLine, string commandLine)
//     {
//         // For now, just process simple expressions like "1 + 1"
//         try
//         {
//             string trimmed = userInput.Trim();
//             var result = EvaluateExpression(trimmed); // see below

//             return new SendToBackendResult
//             {
//                 EquationLine = $"{equationLine} {userInput} = {result}",
//                 CommandLine = commandLine,
//                 Output = result.ToString()
//             };
//         }
//         catch (Exception ex)
//         {
//             throw new InvalidOperationException("Invalid input: " + ex.Message);
//         }
//     }

//     private double EvaluateExpression(string input)
//     {
//         // Basic implementation — for MVP, you could use DataTable
//         var table = new System.Data.DataTable();
//         return Convert.ToDouble(table.Compute(input, string.Empty));
//     }
// }
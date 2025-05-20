using Microsoft.AspNetCore.Mvc;
using PortfolioBackend._Config.ErrorCodes;
using PortfolioBackend.Models.Calculator;

namespace APIWithControllers.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateController : ControllerBase
{
  private readonly ILogger<CalculateController> _logger;

  public CalculateController(ILogger<CalculateController> logger)
  {
    _logger = logger;
  }

  [HttpPost(Name = "Calculate")]
  public StandardResponse<CalculateResponse> Post([FromBody] CalculateRequest request)
  {
    if (!ModelState.IsValid)
    {
      Console.WriteLine("Invalid request");
      return StandardResponseUtils.CreateErrorResponse<CalculateResponse>(
        new List<StandardError>
        {
          new StandardError(ApiServerErrors.InvalidRequest, "Invalid request", request)
        },
        400
      );
    }
    
    return StandardResponseUtils.CreateSuccessResponse(
      new CalculateResponse
      {
        equation_line = request.equation_line,
        command_line = request.command_line,
        user_input = request.user_input
      }
    );
  }
}


// public class CalculateRequest
// {
//     public required string user_input { get; set; }
//     public required string command_line { get; set; }
//     public required string equation_line { get; set; }
// }
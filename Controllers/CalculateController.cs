using Microsoft.AspNetCore.Mvc;
using PortfolioBackend._Config.ErrorCodes;
using PortfolioBackend.Models.Calculator;


namespace APIWithControllers.Controllers
{
  /// <summary>
  /// Controller responsible for handling calculation-related API requests.
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class CalculateController : ControllerBase
  {
    private readonly ILogger<CalculateController> _logger;
    private readonly IResponseBuilder _responseBuilder; 
    private readonly CalculatorService _calculatorService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateController"/> class.
    /// </summary>
    public CalculateController(
        ILogger<CalculateController> logger,
        IResponseBuilder responseBuilder,
        CalculatorService calculatorService)
    {
        _logger = logger;
        _responseBuilder = responseBuilder;
        _calculatorService = calculatorService;
    }


    /// <summary>
    /// Handles POST requests to perform a calculation based on user input and command parameters.
    /// </summary>
    [HttpPost(Name = "Calculate")]
    public StandardResponse<CalculateResponse> Post([FromBody] CalculateRequest request)
    {
      if (!ModelState.IsValid)
      {
        return _responseBuilder.CreateErrorResponse<CalculateResponse>(new List<StandardError>
          {
            _responseBuilder.CreateError(ApiServerErrors.INVALID_REQUEST, "Invalid input", request)
          }, 400);
      }
      else
      {
        return _calculatorService.Evaluate(request.user_input, request.equation_line, request.command_line);
      }
    }
  }
}




// public class CalculateRequest
// {
//     public required string user_input { get; set; }
//     public required string command_line { get; set; }
//     public required string equation_line { get; set; }
// }
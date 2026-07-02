using Microsoft.AspNetCore.Mvc;
using MonthlyPremiumCalculator.Core.DTO;

[ApiController]
[Route("api/[controller]")]
public class PremiumController : ControllerBase
{
    private readonly IPremiumService _service;
    private readonly ILogger<PremiumController> _logger;
    public PremiumController(
        IPremiumService service,
        ILogger<PremiumController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost("calculate")]
    public IActionResult Calculate(
        PremiumRequestDto request)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _logger.LogInformation(
            "Premium calculation request received for {Name}",
            request.Name);

        var premium =
            _service.CalculatePremium(
                request.DeathSumInsured,
                request.Age,
                request.Occupation);
        
        var response =
            new PremiumResponseDto
            {
                MonthlyPremium = premium
            };
        _logger.LogInformation(
            "Premium calculated successfully. Amount: {Premium}",
            premium);

        return Ok(response);
    }
    
    [HttpGet("exception")]
    public IActionResult TestException()
    {
        throw new Exception("Testing Middleware");
    }
}
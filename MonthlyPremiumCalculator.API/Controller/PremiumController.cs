using Microsoft.AspNetCore.Mvc;
using MonthlyPremiumCalculator.Core.DTO;

[ApiController]
[Route("api/[controller]")]
public class PremiumController : ControllerBase
{
    private readonly IPremiumService _service;
    public PremiumController(
        IPremiumService service)
    {
        _service = service;
    }

    [HttpPost("calculate")]
    public IActionResult Calculate(
        PremiumRequestDto request)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
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


        return Ok(response);
    }
    
}
using Microsoft.AspNetCore.Mvc;
using MonthlyPremiumCalculator.Core.DTO;
using MonthlyPremiumCalculator.Core.Interfaces;

namespace MonthlyPremiumCalculator.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class OccupationController : ControllerBase
{
    private readonly IOccupationRepository _repo;

    public OccupationController(
        IOccupationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetOccupations()
    {
        
        var data = _repo.GetOccupations()
            .Select(x => new OccupationDto
            {
                Name = x.Name,
                Rating = x.Rating
            });

        return Ok(data);
    }
}
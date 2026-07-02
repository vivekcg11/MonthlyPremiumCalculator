using Microsoft.Extensions.Logging;
using MonthlyPremiumCalculator.Core.Interfaces;

public class PremiumService : IPremiumService
{
    private readonly IOccupationRepository _repository;
    private readonly ILogger<PremiumService> _logger;

    public PremiumService(IOccupationRepository repository, ILogger<PremiumService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public decimal CalculatePremium(
    decimal deathCover,
    int age,
    string occupation)
    {
        _logger.LogInformation(
            "Calculating premium for occupation {Occupation}",
            occupation);

        var occupationData =
            _repository.GetOccupation(occupation);

        if (occupationData == null)
        {
            _logger.LogWarning(
                "Invalid occupation selected {Occupation}",
                occupation);

            throw new ArgumentException(
                $"Occupation '{occupation}' not found.");
        }

        
        var premium =
            (deathCover * occupationData.Factor * age)
            / 1000 * 12;

        _logger.LogInformation(
            "Premium calculation completed.");

        return premium;

    }   
}
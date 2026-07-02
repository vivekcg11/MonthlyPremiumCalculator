using Microsoft.Extensions.Logging;
using MonthlyPremiumCalculator.Core.Interfaces;

public class PremiumService : IPremiumService
{
    private readonly IOccupationRepository _repository;

    public PremiumService(IOccupationRepository repository, ILogger<PremiumService> logger)
    {
        _repository = repository;
    }

    public decimal CalculatePremium(
    decimal deathCover,
    int age,
    string occupation)
    {

        var occupationData =
            _repository.GetOccupation(occupation);

        if (occupationData == null)
        {
            throw new ArgumentException(
                $"Occupation '{occupation}' not found.");
        }

        
        var premium =
            (deathCover * occupationData.Factor * age)
            / 1000 * 12;

        return premium;

    }   
}
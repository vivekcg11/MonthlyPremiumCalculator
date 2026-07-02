using MonthlyPremiumCalculator.Core.Interfaces;

public class PremiumService : IPremiumService
{
    private readonly IOccupationRepository _repository;

    public PremiumService(IOccupationRepository repository)
    {
        _repository = repository;
    }

    public decimal CalculatePremium(
    decimal deathCover,
    int age,
    string occupation)
    {
        if (deathCover <= 0)
        {
            return 0;
        }

        if (age <= 0)
        {
            throw new ArgumentException(
                "Age must be greater than zero.");
        }

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
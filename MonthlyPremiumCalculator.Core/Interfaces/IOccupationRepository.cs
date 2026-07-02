using MonthlyPremiumCalculator.Core.Models;
public interface IOccupationRepository
{
    IEnumerable<Occupation> GetOccupations();

    Occupation GetOccupation(string occupationName);
}
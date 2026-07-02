using MonthlyPremiumCalculator.Core.Models;

namespace MonthlyPremiumCalculator.Core.Interfaces;

public interface IOccupationRepository
{
    IEnumerable<Occupation> GetOccupations();

    Occupation GetOccupation(string occupationName);
}
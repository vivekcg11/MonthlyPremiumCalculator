public interface IPremiumService
{
    decimal CalculatePremium(
        decimal deathCover,
        int age,
        string occupation);
}
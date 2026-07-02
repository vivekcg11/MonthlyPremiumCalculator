using MonthlyPremiumCalculator.Core.Models;
public class OccupationRepository : IOccupationRepository
{
    private readonly List<Occupation> _occupations =
    [
        new()
        {
            Name="Doctor",
            Rating="Professional",
            Factor=1.5M
        },

        new()
        {
            Name="Author",
            Rating="White Collar",
            Factor=2.25M
        },

        new()
        {
            Name="Cleaner",
            Rating="Light Manual",
            Factor=11.50M
        },

        new()
        {
            Name="Farmer",
            Rating="Heavy Manual",
            Factor=31.75M
        },

        new()
        {
            Name="Mechanic",
            Rating="Heavy Manual",
            Factor=31.75M
        },

        new()
        {
            Name="Florist",
            Rating="Light Manual",
            Factor=11.5M
        },

        new()
        {
            Name="Other",
            Rating="Heavy Manual",
            Factor=31.75M
        }
    ];
}
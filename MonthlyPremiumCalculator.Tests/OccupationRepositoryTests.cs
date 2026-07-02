using Moq;
using FluentAssertions;
using MonthlyPremiumCalculator.Infrastructure;
using Microsoft.Extensions.Logging;

public class OccupationRepositoryTests
{
    
    [Fact]
    public void GetOccupation_ShouldReturnDoctor()
    {
        var loggerMock = new Mock<ILogger<OccupationRepository>>();

        var repo =
            new OccupationRepository(loggerMock.Object);

        var occupation =
            repo.GetOccupation("Doctor");

        occupation.Should().NotBeNull();

        occupation.Name.Should().Be("Doctor");
    }
}
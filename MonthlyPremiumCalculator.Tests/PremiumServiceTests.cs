using Moq;
using MonthlyPremiumCalculator.Core.Models;
using MonthlyPremiumCalculator.Core.Interfaces;
using FluentAssertions;

public class PremiumServiceTests
{
    private readonly Mock<IOccupationRepository> _repoMock = new();

    [Fact]
    public void CalculatePremium_ShouldReturnValue()
    {
        _repoMock
           .Setup(x=>x.GetOccupation("Doctor"))
           .Returns(new Occupation
           {
               Factor=1.5M
           });

        var service =
            new PremiumService(_repoMock.Object);

        var result =
            service.CalculatePremium(
                500000,
                35,
                "Doctor");

        Assert.True(result > 0);
    }

    [Fact]
    public void CalculatePremium_Doctor_ReturnsExpectedPremium()
    {
        _repoMock.Setup(x => x.GetOccupation("Doctor"))
            .Returns(new Occupation
            {
                Factor = 1.5M
            });

        var service = new PremiumService(_repoMock.Object);

        var result = service.CalculatePremium(
            500000,
            35,
            "Doctor");

        result.Should().Be(315000);
    }

    [Fact]
    public void CalculatePremium_Author_ReturnsExpectedPremium()
    {
        _repoMock.Setup(x => x.GetOccupation("Author"))
        .Returns(new Occupation
        {
            Factor = 2.25M
        });

        var service = new PremiumService(_repoMock.Object);

        var result = service.CalculatePremium(
            100000,
            25,
            "Author");

        result.Should().Be(67500);
    }
    [Fact]
    public void CalculatePremium_Cleaner_ReturnsExpectedPremium()
    {
        _repoMock.Setup(x => x.GetOccupation("Cleaner"))
            .Returns(new Occupation
            {
                Factor = 11.5M
            });

        var service = new PremiumService(_repoMock.Object);

        var result = service.CalculatePremium(
            100000,
            30,
            "Cleaner");

        result.Should().Be(414000);
    }
    [Fact]
    public void CalculatePremium_Farmer_ReturnsExpectedPremium()
    {
        _repoMock.Setup(x => x.GetOccupation("Farmer"))
            .Returns(new Occupation
            {
                Factor = 31.75M
            });

        var service = new PremiumService(_repoMock.Object);

        var result = service.CalculatePremium(
            100000,
            30,
            "Farmer");

        result.Should().Be(1143000);
    }
    [Fact]
    public void CalculatePremium_InvalidOccupation_ThrowsException()
    {
        _repoMock.Setup(x => x.GetOccupation(It.IsAny<string>()))
            .Returns((Occupation)null);

        var service = new PremiumService(_repoMock.Object);

        Action act = () =>
            service.CalculatePremium(
                100000,
                30,
                "Pilot");

        act.Should()
            .Throw<ArgumentException>();
    }
    [Fact]
    public void CalculatePremium_ZeroDeathCover_ReturnsZero()
    {
        _repoMock.Setup(x => x.GetOccupation("Doctor"))
            .Returns(new Occupation
            {
                Factor = 1.5M
            });

        var service = new PremiumService(_repoMock.Object);

        var result =
            service.CalculatePremium(
                0,
                30,
                "Doctor");

        result.Should().Be(0);
    }
    [Fact]
    public void CalculatePremium_ZeroAge_ThrowsException()
    {
        _repoMock.Setup(x => x.GetOccupation("Doctor"))
            .Returns(new Occupation
            {
                Factor = 1.5M
            });

        var service = new PremiumService(_repoMock.Object);

        Action act = () =>
            service.CalculatePremium(
                500000,
                0,
                "Doctor");

        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("*Age must be greater than zero*");
    }
    [Fact]
    public void CalculatePremium_NegativeAge_ShouldThrowException()
    {
        _repoMock.Setup(x => x.GetOccupation("Doctor"))
            .Returns(new Occupation
            {
                Factor = 1.5M
            });

        var service = new PremiumService(_repoMock.Object);

        Action act = () =>
            service.CalculatePremium(
                100000,
                -5,
                "Doctor");

        act.Should()
            .Throw<ArgumentException>();
    }
}
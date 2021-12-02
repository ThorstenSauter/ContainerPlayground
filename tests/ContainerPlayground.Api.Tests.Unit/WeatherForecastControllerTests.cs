using ContainerPlayground.Api.Controllers;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace ContainerPlayground.Api.Tests.Unit;

public class WeatherForecastControllerTests
{
    private readonly WeatherForecastController _sut;

    public WeatherForecastControllerTests()
    {
        var logger = Substitute.For<ILogger<WeatherForecastController>>();
        _sut = new(logger);
    }

    [Fact]
    public void Get_AllValid_ReturnFiveForecasts()
    {
        // Arrange

        // Act
        var forecasts = _sut.Get();

        // Assert
        forecasts.Count().Should().Be(5);
    }
}
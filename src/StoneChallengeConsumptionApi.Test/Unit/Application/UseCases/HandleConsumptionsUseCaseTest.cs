using Microsoft.Extensions.Logging;
using Moq;
using StoneChallengeBillingApi.Test.Unit.Fixtures;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions;
using StoneChallengeConsumptionApi.Domain.Clients;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;

namespace StoneChallengeConsumptionApi.Test.Unit.Application.UseCases;

[Collection(nameof(ConsumptionCollection))]
public class HandleConsumptionsUseCaseTest
{
    private readonly ConsumptionTestFixture _fixture;

    public HandleConsumptionsUseCaseTest(ConsumptionTestFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact(DisplayName = "Handle Consumptions")]
    public async Task ItShouldBeAbleToHandleConsumption()
    {
        // Arrange
        var arr = _fixture.GenerateValidRequestDto();
        var arr2 = _fixture.GenerateCustomersReadModel(5);
        var mockCustomerRefit = new Mock<ICustomersApiClient>();
        var mockBillingRefit = new Mock<IBillingsApiClient>();
        var mockLogger = new Mock<ILogger<HandleConsumptionsUseCase>>();

        mockCustomerRefit.Setup(x => x.GetAllAsync())
            .ReturnsAsync(() => arr2);

        var sut = new HandleConsumptionsUseCase(mockLogger.Object, mockCustomerRefit.Object, mockBillingRefit.Object);

        // Act
        var result = await sut.ExecuteAsync(arr);

        // Assert
        Assert.IsType<SuccessOperation>(result);
    }
    
    [Fact(DisplayName = "Handle Consumptions")]
    public async Task ItShouldNotBeAbleToHandleConsumptionWhenInvalidDataWasPassed()
    {
        // Arrange
        var arr = _fixture.GenerateInvalidRequestDto();
        var mockCustomerRefit = new Mock<ICustomersApiClient>();
        var mockBillingRefit = new Mock<IBillingsApiClient>();
        var mockLogger = new Mock<ILogger<HandleConsumptionsUseCase>>();

        var sut = new HandleConsumptionsUseCase(mockLogger.Object, mockCustomerRefit.Object, mockBillingRefit.Object);

        // Act
        var result = await sut.ExecuteAsync(arr);

        // Assert
        Assert.IsType<FailedOperation>(result);
    }
}
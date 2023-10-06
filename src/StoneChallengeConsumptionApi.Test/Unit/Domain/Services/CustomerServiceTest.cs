// using Moq;
// using StoneChallengeConsumptionApi.Domain.Interfaces.Repositories;
// using StoneChallengeConsumptionApi.Domain.Models;
// using StoneChallengeConsumptionApi.Domain.Services;
// using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;
// using StoneChallengeConsumptionApi.Test.Unit.Fixtures;
//
// namespace StoneChallengeConsumptionApi.Test.Unit.Domain.Services;
//
// [Collection(nameof(CustomerCollection))]
// public class CustomerServiceTest
// {
//     private readonly CustomerTestFixture _fixture;
//
//
//     public CustomerServiceTest(CustomerTestFixture fixture)
//     {
//         _fixture = fixture;
//     }
//
//     [Fact(DisplayName = "Create a Valid Consumption")]
//     public async Task ItShouldBeAbleToCreateABilling()
//     {
//         // Arrange
//         var arr = _fixture.GenerateValidCustomer();
//         var mockRepo = new Mock<ICustomersRepository>();
//
//         mockRepo.Setup(x => x.CreateAsync(It.IsAny<Consumption>()))
//             .ReturnsAsync(() => arr);
//
//         var sut = new ConsumptionService(mockRepo.Object);
//
//         // Act
//         var result = await sut.CreateAsync(arr);
//
//         // Assert
//         Assert.Equal(result.Data.Cpf.Value, arr.Cpf.Value);
//     }
//
//     [Fact(DisplayName = "Create a Invalid Billing")]
//     public async Task ItShouldNotBeAbleToCreateABillingWithInvalidProps()
//     {
//         // Arrange
//         var arr = _fixture.GenerateInvalidCustomer();
//         var mockRepo = new Mock<ICustomersRepository>();
//
//         var sut = new ConsumptionService(mockRepo.Object);
//
//         // Act
//         var result = await sut.CreateAsync(arr);
//
//         // Assert
//         Assert.IsType<FailedOperation<Consumption>>(result);
//     }
// }
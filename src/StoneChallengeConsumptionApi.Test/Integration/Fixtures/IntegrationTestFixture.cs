using Bogus;
using Bogus.Extensions.Brazil;
using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Domain.ValueObjects;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Helpers;
using StoneChallengeConsumptionApi.Test.Integration.Config;

namespace StoneChallengeConsumptionApi.Test.Integration.Fixtures;

[CollectionDefinition(nameof(IntegrationTestFixtureCollection))]
public class IntegrationTestFixtureCollection : ICollectionFixture<IntegrationTestFixture> { }

public class IntegrationTestFixture : IDisposable
{
    private readonly ConsumptionAppFactory Factory;
    public readonly HttpClient Client;

    public IntegrationTestFixture()
    {
        Factory = new ConsumptionAppFactory();
        Client = Factory.CreateClient();
    }

    public async Task<HttpResponseMessage> GetSwagger()
        => await Client.GetAsync("/swagger/v1/swagger.json");
    
    public CreateConsumptionsRequestDTO GenerateValidRequestDto()
        => new()
        {
            ReferenceDate = DateTimeHelpers.GetSouthAmericaDateTimeNow().Date.ToString("dd/MM/yyyy")
        };

    public void Dispose()
    {
        Client.Dispose();
        Factory?.Dispose();
    }
}
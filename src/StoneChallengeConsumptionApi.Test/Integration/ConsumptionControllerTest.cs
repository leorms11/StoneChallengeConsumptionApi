using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions.Interfaces;
using StoneChallengeConsumptionApi.Infra.CrossCutting.IoC;
using StoneChallengeConsumptionApi.Test.Integration.Fixtures;

namespace StoneChallengeConsumptionApi.Test.Integration;

[Collection(nameof(IntegrationTestFixtureCollection))]
public class ConsumptionControllerTest
{
    private readonly IntegrationTestFixture _fixture;

    public ConsumptionControllerTest(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ItShouldBeAbleToHandleConsumption()
    {
        var arr = _fixture.GenerateValidRequestDto();
        var response = await _fixture.Client.PostAsJsonAsync("api/v1/consumptions", arr);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
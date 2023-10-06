using Bogus;
using Bogus.Extensions.Brazil;
using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Domain.ReadModels;
using StoneChallengeConsumptionApi.Domain.ValueObjects;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Helpers;

namespace StoneChallengeBillingApi.Test.Unit.Fixtures;

[CollectionDefinition(nameof(ConsumptionCollection))]
public class ConsumptionCollection : ICollectionFixture<ConsumptionTestFixture> {}

public class ConsumptionTestFixture : IDisposable
{
    public Cpf GenerateValidCpf()
    {
        var isValid = false;
        var cpf = new Cpf(string.Empty);
        
        while (!isValid)
        {
            cpf = new Cpf(new Faker().Person.Cpf());
            isValid = cpf.IsValid;
        }

        return cpf;
    }

    public IEnumerable<CustomerReadModel> GenerateCustomersReadModel(int total)
    {
        for (int i = 1; i <= total; i++)
        {
            yield return new()
            {
                Cpf = GenerateValidCpf().Value.ToString(),
                Name = new Faker().Person.FullName
            };
        }
    }

    public CreateConsumptionsRequestDTO GenerateValidRequestDto()
        => new()
        {
            ReferenceDate = DateTimeHelpers.GetSouthAmericaDateTimeNow().Date.ToString("dd/MM/yyyy")
        };
    
    public CreateConsumptionsRequestDTO GenerateInvalidRequestDto()
        => new()
        {
            ReferenceDate = "wrong_date"
        };

    public void Dispose()
    {
    }
}
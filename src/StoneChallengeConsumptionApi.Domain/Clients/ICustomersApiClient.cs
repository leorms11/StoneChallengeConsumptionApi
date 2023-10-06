using Refit;
using StoneChallengeConsumptionApi.Domain.ReadModels;

namespace StoneChallengeConsumptionApi.Domain.Clients;

public interface ICustomersApiClient
{
    [Get("/v1/customers")]
    Task<IEnumerable<CustomerReadModel>> GetAllAsync();
}
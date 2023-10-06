using Refit;
using StoneChallengeConsumptionApi.Domain.Clients.DTOs;

namespace StoneChallengeConsumptionApi.Domain.Clients;

public interface IBillingsApiClient
{
    [Post("/v1/billings")]
    Task CreateAsync([Body] CreateBillingRequestDTO body);
}
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StoneChallengeConsumptionApi.Domain.Clients.DTOs;

public class CreateBillingRequestDTO
{
    [JsonPropertyName("dueDate"), JsonProperty("dueDate")]
    public DateTime DueDate { get; init; }

    [JsonPropertyName("cpf"), JsonProperty("cpf")]
    public string Cpf { get; init; }

    [JsonPropertyName("billingAmount"), JsonProperty("billingAmount")]
    public decimal BillingAmount { get; init; }
}
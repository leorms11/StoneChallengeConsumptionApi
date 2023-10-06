using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StoneChallengeConsumptionApi.Domain.ReadModels;

public class CustomerReadModel
{
    [JsonPropertyName("name"), JsonProperty("name")]
    public string Name { get; init; }
    
    [JsonPropertyName("cpf"), JsonProperty("cpf")]
    public string Cpf { get; init; }
}
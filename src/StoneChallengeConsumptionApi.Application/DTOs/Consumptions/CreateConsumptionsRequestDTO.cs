using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;

namespace StoneChallengeConsumptionApi.Application.DTOs.Consumptions;

public class CreateConsumptionsRequestDTO : Notifiable
{
    [JsonPropertyName("referenceDate"), JsonProperty("referenceDate")]
    public string? ReferenceDate { get; init; }
}
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Enums;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;

namespace StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;

public class FailedOperation : IOperation
{
    public FailedOperation() { }

    public FailedOperation(EErrorType type, IEnumerable<ResultErrorField> fields, string reason)
    {
        Reason = reason;
        Errors = new ResultError(type, fields);
    }
    
    [JsonPropertyName("reason"), JsonProperty("reason")]
    public string? Reason { get; }
    
    [JsonPropertyName("errors"), JsonProperty("errors")]
    public ResultError? Errors { get; }
}
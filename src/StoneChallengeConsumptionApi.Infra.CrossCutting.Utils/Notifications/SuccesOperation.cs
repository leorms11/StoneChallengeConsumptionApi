using System.Text.Json.Serialization;
using Newtonsoft.Json;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;

namespace StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;

public class SuccessOperation : IOperation
{
    public SuccessOperation() { }
    
    [JsonPropertyName("reason"), JsonProperty("reason")]
    public string? Reason { get; }
    
    [JsonPropertyName("erros"), JsonProperty("erros")]
    public ResultError? Errors { get; }
}

public class SuccessOperation<T> : SuccessOperation, IOperation<T>
{
    public SuccessOperation(T data)
    {
        Data = data;
    }
    
    [JsonPropertyName("reason"), JsonProperty("reason")]
    public string? Reason { get; }
    
    [JsonPropertyName("erros"), JsonProperty("erros")]
    public ResultError? Errors { get; }

    [JsonPropertyName("data"), JsonProperty("data")]
    public T Data { get; }
}
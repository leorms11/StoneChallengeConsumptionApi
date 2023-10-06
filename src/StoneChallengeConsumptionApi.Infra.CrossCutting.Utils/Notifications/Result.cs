using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Extensions;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Enums;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;

namespace StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;

public static class Result
{
    public static IOperation CreateSuccess()
        => new SuccessOperation();
    
    public static IOperation CreateFailure(EErrorType type, IEnumerable<ResultErrorField> fields)
        => new FailedOperation(type, fields, type.GetDescription());
}
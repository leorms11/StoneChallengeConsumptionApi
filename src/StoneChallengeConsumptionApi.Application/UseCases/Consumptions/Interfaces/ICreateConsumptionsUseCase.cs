using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;

namespace StoneChallengeConsumptionApi.Application.UseCases.Consumptions.Interfaces;

public interface ICreateConsumptionsUseCase
{
    Task<IOperation> ExecuteAsync(CreateConsumptionsRequestDTO dto);
}
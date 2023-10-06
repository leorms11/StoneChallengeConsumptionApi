using Microsoft.Extensions.Logging;
using StoneChallenge.CrossCutting.Utils.Helpers;
using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions.Interfaces;
using StoneChallengeConsumptionApi.Application.Validators.Consumptions;
using StoneChallengeConsumptionApi.Domain.Clients;
using StoneChallengeConsumptionApi.Domain.Clients.DTOs;
using StoneChallengeConsumptionApi.Domain.ReadModels;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Helpers;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Enums;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;

namespace StoneChallengeConsumptionApi.Application.UseCases.Consumptions;

public class HandleConsumptionsUseCase : ICreateConsumptionsUseCase
{
    private readonly ILogger<HandleConsumptionsUseCase> _logger;
    private readonly ICustomersApiClient _customersApiClient;
    private readonly IBillingsApiClient _billingsApiClient;

    public HandleConsumptionsUseCase(ILogger<HandleConsumptionsUseCase> logger, 
        ICustomersApiClient customersApiClient, 
        IBillingsApiClient billingsApiClient)
    {
        _logger = logger;
        _customersApiClient = customersApiClient;
        _billingsApiClient = billingsApiClient;
    }

    public async Task<IOperation> ExecuteAsync(CreateConsumptionsRequestDTO dto)
    {
        _logger.LogInformation("Iniciando cálculo e persistencia das cobranças para os clientes.");

        dto.Validate(dto, CreateConsumptionsValidator.Instance);
        
        if (!dto.IsValid)
            return Result.CreateFailure(EErrorType.InvalidData, dto.Notifications);
        
        var customers = await _customersApiClient.GetAllAsync();

        await Parallel.ForEachAsync(ConstructBillings(customers, dto.ReferenceDate),
            async (requestDto, token) => await _billingsApiClient.CreateAsync(requestDto));
            
        return Result.CreateSuccess();
    }

    private IEnumerable<CreateBillingRequestDTO> ConstructBillings(IEnumerable<CustomerReadModel> customers, 
        string? referenceDateString)
    {
        foreach (var customer in customers)
        {
            var referenceDate = DateTime.Parse(referenceDateString);

            var billingAmount = 
                    decimal.Parse($"{customer.Cpf.GetFirstCharacters(2)}{customer.Cpf.GetLastCharacters(2)}");

            yield return new()
            {
                Cpf = customer.Cpf,
                BillingAmount = billingAmount,
                DueDate = referenceDate.Date
            };
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions.Interfaces;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Notifications.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace StoneChallengeConsumptionApi.Presentation.Controllers;

[ApiVersion("1.0")]
[Consumes("application/json")]
[Route("api/v{version:apiVersion}/consumptions", Name = "Consumptions")]
public class ConsumptionController : BaseController
{
    private readonly ICreateConsumptionsUseCase _createConsumptionsUseCase;

    public ConsumptionController(ICreateConsumptionsUseCase createConsumptionsUseCase)
    {
        _createConsumptionsUseCase = createConsumptionsUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
    [SwaggerOperation(Summary = "Calcular e criar os consumos para os clientes.")]
    public async Task<ActionResult<IOperation>> CreateAsync([FromBody] CreateConsumptionsRequestDTO dto)
    {
        var result = await _createConsumptionsUseCase.ExecuteAsync(dto);

        return result is FailedOperation ? BadRequest(result) : Ok();
    }
}
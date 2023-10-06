using FluentValidation;
using StoneChallengeConsumptionApi.Application.DTOs.Consumptions;
using StoneChallengeConsumptionApi.Domain.ValueObjects;
using StoneChallengeConsumptionApi.Infra.CrossCutting.Utils.Constants;

namespace StoneChallengeConsumptionApi.Application.Validators.Consumptions;

public class CreateConsumptionsValidator : AbstractValidator<CreateConsumptionsRequestDTO>
{
    public static readonly CreateConsumptionsValidator Instance = new();

    public CreateConsumptionsValidator()
    {
        RuleFor(dto => dto.ReferenceDate)
            .NotEmpty()
            .WithMessage(Constants.PropIsMissing)
            .NotNull()
            .WithMessage(Constants.PropIsMissing)
            .Must(x => DateTime.TryParse(x, out _))
            .WithMessage(Constants.InvalidDate);
    }
}
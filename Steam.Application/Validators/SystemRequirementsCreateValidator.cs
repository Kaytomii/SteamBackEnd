using FluentValidation;
using Steam.Application.DTOs.SystemRequirementsDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Validators;

public class SystemRequirementsCreateValidator : AbstractValidator<SystemRequirementsCreateDTO>
{
    public SystemRequirementsCreateValidator()
    {
        RuleFor(x => x.GameId).GreaterThan(0).WithMessage("GameId должен быть положительным");
        RuleFor(x => x.Os).NotEmpty().WithMessage("Os обязательный");
    }
}
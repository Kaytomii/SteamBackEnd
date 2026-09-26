using FluentValidation;
using Steam.Application.DTOs.AchievementDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Validators;

public class AchievementCreateValidator : AbstractValidator<AchievementCreateDTO>
{
    public AchievementCreateValidator()
    {
        RuleFor(x => x.GameId).GreaterThan(0).WithMessage("GameId должен быть положительным");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title обязательный");
    }
}
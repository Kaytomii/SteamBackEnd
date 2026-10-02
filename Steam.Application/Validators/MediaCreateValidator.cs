using FluentValidation;
using Steam.Application.DTOs.MediaDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.Application.Validators;

public class MediaCreateValidator : AbstractValidator<MediaCreateDTO>
{
    public MediaCreateValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
        RuleFor(x => x.Url).NotEmpty().WithMessage("Url обязательный");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type обязательный");
    }
}
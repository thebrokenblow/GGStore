using FluentValidation;

namespace GGStore.Domain.GameDomain;

public class CreateGameValidation : AbstractValidator<GameDto>
{
    public CreateGameValidation()
    {
        RuleFor(gameDto => gameDto.Title)
            .NotEmpty()
            .MaximumLength(250);
    }
}
using FluentValidation;
using POS.Application.Dtos.Request;

namespace POS.Application.Validators.User;

internal class UserValidator : AbstractValidator<UserRequestDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("El campo Nombre no pude ser nulo").NotEmpty().WithMessage("El campo Nombre no pude ser vacio");
    }

}

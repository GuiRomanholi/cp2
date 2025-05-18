using cp2.Application.DTOs.Request;
using FluentValidation;

namespace cp2.Application.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequest>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
        }
    }
}

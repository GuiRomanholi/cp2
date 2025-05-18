using cp2.Application.DTOs.Request;
using FluentValidation;

namespace cp2.Application.Validators
{
    public class MotoValidator : AbstractValidator<MotoRequest>
    {
        public MotoValidator()
        {
            RuleFor(m => m.Modelo)
                .NotEmpty().WithMessage("Modelo é obrigatório");

            RuleFor(m => m.Placa)
                .NotEmpty().WithMessage("Placa é obrigatória")
                .Length(7).WithMessage("A placa deve ter 7 caracteres");

            RuleFor(m => m.UsuarioId)
                .NotEqual(Guid.Empty).WithMessage("Usuário associado é obrigatório");
        }
    }
}

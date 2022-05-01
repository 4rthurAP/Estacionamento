using Estacionamento.Domain.Models.Bussiness;
using FluentValidation;
using FluentValidation.Results;

namespace Estacionamento.Domain.Validations
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(f => f.IsFree)
                .Custom((value, contetx) => 
                {
                    if (value)
                        contetx.AddFailure(new ValidationFailure(null, "O Estacionamento é gratis"));
                });
        }
    }
}

using FluentValidation;
using Venda_BackEnd.Entites;

namespace Venda_BackEnd.FluentValidador
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("nome obrigatório.");
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("cpf obrigatório.");
            RuleFor(x => x.Endereco).NotEmpty().WithMessage("endereço obrigatório.");
            RuleFor(x => x.DataNascimento).LessThan(DateTime.Now).WithMessage("data de nascimento não pode ser maior que data atual");
            RuleFor(x => x.Email).EmailAddress().WithMessage("e-mail inválido.");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("número de telefone inválido.");
        }
    }
}

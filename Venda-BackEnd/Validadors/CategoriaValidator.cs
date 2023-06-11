using FluentValidation;
using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Validadors
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("nome obrigatório.");
        }
    }
}

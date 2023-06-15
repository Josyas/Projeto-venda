using FluentValidation;
using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Validadors
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty().WithMessage("o campo codigo é obrigatório.");
            RuleFor(x => x.Preco).NotEmpty().WithMessage("o campo preço é obrigatório.");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("o campo descrição é obrigatório.");
            RuleFor(x => x.IdCategoria).NotEmpty().WithMessage("o campo categoria é obrigatório.");
        }
    }
}

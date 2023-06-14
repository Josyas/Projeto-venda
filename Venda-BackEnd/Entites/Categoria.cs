namespace Venda_BackEnd.Entites
{
    public class Categoria : ObjetoBase
    {
        public Categoria(int idCategoria, string nome) : base(nome)
        {
            IdCategoria = idCategoria;
        }

        public int IdCategoria { get; private set; }
    }
}

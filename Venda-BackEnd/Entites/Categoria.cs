namespace Venda_BackEnd.Entites
{
    public class Categoria : ObjetoBase
    {
        public Categoria(string nome) : base(nome)
        { 
        }

        public int IdCategoria { get; private set; }
    }
}

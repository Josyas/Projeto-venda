namespace Venda_BackEnd.Entites
{
    public abstract class ObjetoBase
    {
        public ObjetoBase(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; protected set; }
    }
}

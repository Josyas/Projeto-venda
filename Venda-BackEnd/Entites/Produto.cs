namespace Venda_BackEnd.Entites
{
    public class Produto : ObjetoBase
    {
        public Produto() : base(string.Empty)
        {
        }

        public Produto(string nome, int codigo, float preco, string descricao, int idCategoria) : base(nome)
        {
            Codigo = codigo;
            Preco = preco;
            Descricao = descricao;
            IdCategoria = idCategoria;
        }

        public int Codigo { get; private set; }
        public float Preco { get; private set; }
        public string Descricao { get; private set; }
        public int IdCategoria { get; private set; }
        public Categoria Categoria { get; set; }
    }
}

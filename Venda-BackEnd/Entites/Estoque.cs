namespace Venda_BackEnd.Entites
{
    public class Estoque
    {
        public Estoque(int quantidade, int idProduto)
        {
            Quantidade = quantidade;
            IdProduto = idProduto;
        }

        public int IdEstoque { get; private set; }
        public int Quantidade { get; private set; }
        public int IdProduto { get; private set; }
        public Produto produto { get; private set; }
    }
}

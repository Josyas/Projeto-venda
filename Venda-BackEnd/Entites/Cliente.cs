namespace Venda_BackEnd.Entites
{
    public class Cliente : ObjetoBase
    {
        public Cliente(int cpf, string nome, string endereco, DateTime dataNascimento, string telefone, string email) : base(nome)
        {
            Cpf = cpf;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
        }

        public int Cpf { get; private set; }
        public string Endereco { get; private set;}
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
    }
}

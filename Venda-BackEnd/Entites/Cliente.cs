namespace Venda_BackEnd.Entites
{
    public class Cliente
    {
        public Cliente(int cpf, string nome, string endereco, DateTime dataNascimento, string telefone, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
        }

        public int Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set;}
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
    }
}

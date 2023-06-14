document.addEventListener('DOMContentLoaded', function() {
    const formElement = document.querySelector('form');

    formElement.addEventListener('submit', function(event) {
            event.preventDefault(); 
            
            const nome = document.getElementById('nome-input').value;
            const cpf = document.getElementById('cpf-input').value;
            const endereco = document.getElementById('endereco-input').value;
            const dataNascimento =  document.getElementById('data-nascimento-input').value;
            const telefone = document.getElementById('telefone-input').value;
            const email = document.getElementById('email-input').value;

            const cliente = {
                Nome: nome,
                CPF: cpf,
                Endereco: endereco,
                DataNascimento: dataNascimento,
                Telefone: telefone,
                Email: email
            };

            const clienteRequest = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json/' },
                body: JSON.stringify(cliente)
            };
  
            fetch('https://localhost:7180/cliente/novo-cliente', clienteRequest)
            .then(response => {
                if(response.ok){
                    location.reload();
                }
                else{
                    return response.text();
                }
            })
            .then(erro => {
                if(erro){
                    exibirMensagemErro(erro)
                }
            })
    })
})

function exibirMensagemErro(mensagem)
  {
    Swal.fire({
      icon: 'error',
      title: 'Erro',
      text: mensagem,
    });
  }
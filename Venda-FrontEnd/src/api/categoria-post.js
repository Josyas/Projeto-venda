document.addEventListener('DOMContentLoaded', function(){
    const formElement = document.querySelector('form');

    formElement.addEventListener('submit', function(event) {
        event.preventDefault();

        const nome = document.getElementById('nome-input').value;

        const categoria = {
           Nome: nome
        }

        const categoriaRequest = {
            method: 'POST',
            headers: {'Content-Type': 'application/json/'},
            body: JSON.stringify(categoria)
        };

        fetch('https://localhost:7180/categoria/nova-categoria', categoriaRequest)
        .then(response => {
            if(response.ok){
                location.reload();
            }
            else{
                response.text();
            }
        })
        .then(erro => {
            exibirMensagemErro(erro)
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
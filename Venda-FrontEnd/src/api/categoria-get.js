document.addEventListener('DOMContentLoaded', function() {
    const tableBodyElement = document.getElementById('item-table-body');

    fetch('https://localhost:7180/categoria/categorias', { method: 'GET'})
    .then(response => response.json())
    .then(data => {
        for(let i = 0; i < data.length; i++){
  
            const item = data[i];

            const categoriaResponse = {
                IdCategoria: item.idCategoria,
                Nome: item.nome
            }

            const row = document.createElement('tr');

            const nomeCell = document.createElement('td');
            nomeCell.textContent = item.nome;
            row.appendChild(nomeCell);

            const editButton = document.createElement('button');
            editButton.textContent = 'Editar';
            editButton.classList.add('btn', 'btn-primary');
            editButton.style.float = 'right';
            editButton.style.marginRight = '5px';
            
            editButton.addEventListener('click', function(){
                exibirModelEditicao(categoriaResponse);
            })

            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Apagar';
            deleteButton.classList.add('btn', 'btn-danger');
            deleteButton.style.float = 'right';

            deleteButton.addEventListener('click', function(){
                const idCategoria = {
                    Id: categoriaResponse.IdCategoria
                }

                const confirmaApgar = confirm('Deseja excluir o item?');

                if(confirmaApgar){
                    fetch('https://localhost:7180/categoria/remove-categoria', {
                        method: 'DELETE',
                        headers: {'Content-Type': 'application/json'},
                        body: JSON.stringify(idCategoria) 
                    })
                    .then(response => {
                        if(response.ok){
                            location.reload();
                        }
                        else{
                            response.text();
                        }
                    })
                    .then(erro => {
                        if(erro){
                            exibirMensagemErro(erro);
                        }
                    })
                }
            })

            const actionsCell = document.createElement('td');
            actionsCell.classList.add('action-buttons');
                        
            actionsCell.appendChild(deleteButton);
            actionsCell.appendChild(editButton);
        
            row.appendChild(actionsCell);
        
            tableBodyElement.appendChild(row);
        }
    })
})

function exibirModelEditicao(item){

   document.getElementById('edit-nomeInput').value = item.Nome;

   const modal = new bootstrap.Modal(document.getElementById('edit-modal'));
   modal.show();

   const salvarButton = document.getElementById('saveButton');
   salvarButton.addEventListener('click', function(){
        salvarEdicao(item);
   })
}

function salvarEdicao(item) {
    const id = item.IdCategoria;
   const nome = document.getElementById('edit-nomeInput').value;
   debugger
   const categoriaAlterada = {
        IdCategoria: id,
        Nome: nome
   }

   fetch('https://localhost:7180/categoria/atualiza-cliente', {
        method: 'PUT',
        headers: {
        'Content-Type': 'application/json'
        },
        body: JSON.stringify(categoriaAlterada)
   })
   .then(response => {
        if(response.ok){
            location.reload();
        }
        else{
            response.text();
        }
   })
   .then(erro => {
        if(erro){
            exibirMensagemErro(erro);
        }
   })
}

function exibirMensagemErro(mensagem){
    Swal.fire({
      icon: 'error',
      title: 'Erro',
      text: mensagem,
    });
}
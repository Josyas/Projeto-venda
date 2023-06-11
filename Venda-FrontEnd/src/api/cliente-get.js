document.addEventListener('DOMContentLoaded', function(){
    const tableBodyElement = document.getElementById('item-table-body');

    fetch('https://localhost:7180/cliente/clientes', { method: 'GET'})
    .then(response => response.json())
    .then(data => {
        for(let i = 0; i < data.length; i++){
            const item = data[i];
            debugger
            const clienteResponse = {
                Cpf: item.cpf,
                Nome: item.nome,
                Endereco: item.endereco,
                DataNascimento: item.dataNascimento,
                Telefone: item.telefone,
                Email: item.email
            }

            const row = document.createElement('tr');

            const cpfCell = document.createElement('td');
            cpfCell.textContent = item.cpf;
            row.appendChild(cpfCell);
        
            const nomeCell = document.createElement('td');
            nomeCell.textContent = item.nome;
            row.appendChild(nomeCell);
        
            const enderecoCell = document.createElement('td');
            enderecoCell.textContent = item.endereco;
            row.appendChild(enderecoCell);
        
            const dataNascimentoCell = document.createElement('td');
            dataNascimentoCell.textContent = item.dataNascimento.split('T')[0];
            row.appendChild(dataNascimentoCell);

            const telefoneCell = document.createElement('td');
            telefoneCell.textContent = item.telefone;
            row.appendChild(telefoneCell);
        
            const emailCell = document.createElement('td');
            emailCell.textContent = item.email;
            row.appendChild(emailCell);
        
            const editButton = document.createElement('button');
            editButton.textContent = 'Editar';
            editButton.classList.add('btn', 'btn-primary');
            editButton.style.float = 'right';
            editButton.style.marginRight = '5px';

            editButton.addEventListener('click', function(){
                exibirModelEditicao(clienteResponse)
            })
                        
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Apagar';
            deleteButton.classList.add('btn', 'btn-danger');
            deleteButton.style.float = 'right';

            deleteButton.addEventListener('click', function() {
                const itemCpf = {
                    Cpf: clienteResponse.Cpf
                }
                const confirmaApgar = confirm('Deseja excluir o item?');
              
                if(confirmaApgar){
                fetch('https://localhost:7180/cliente/remove-cliente', {
                        method: 'DELETE',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(itemCpf)
                })
                .then(response =>{
                    if(response.ok){
                       location.reload();
                    }
                    else{
                        return response.text();
                    }
                })
                .then(erro =>{
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
    document.getElementById('edit-cpfInput').value = item.Cpf;
    document.getElementById('edit-nomeInput').value = item.Nome;
    document.getElementById('edit-enderecoInput').value = item.Endereco;
    document.getElementById('edit-dataNascimentoInput').value = item.DataNascimento.split('T')[0];
    document.getElementById('edit-telefoneInput').value = item.Telefone;
    document.getElementById('edit-emailInput').value = item.Email;

    const modal = new bootstrap.Modal(document.getElementById('edit-modal'));
    modal.show();

    const salvarButton = document.getElementById('saveButton');
    salvarButton.addEventListener('click', function() {
        salvarEdicao(item);
    });
}

function salvarEdicao(item) {
    const cpf = document.getElementById('edit-cpfInput').value;
    const nome = document.getElementById('edit-nomeInput').value;
    const endereco = document.getElementById('edit-enderecoInput').value;
    const dataNascimento = document.getElementById('edit-dataNascimentoInput').value;
    const telefone = document.getElementById('edit-telefoneInput').value;
    const email = document.getElementById('edit-emailInput').value;

    const clienteAlteracao = {
        Cpf: cpf,
        Nome: nome,
        Endereco: endereco,
        DataNascimento: dataNascimento,
        Telefone: telefone,
        Email: email
    }

    debugger
    fetch('https://localhost:7180/cliente/atualiza-cliente', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(clienteAlteracao)
    })
    .then(response =>{
        if(response.ok){
           location.reload();
        }
        else{
            return response.text();
        }
    })
    .then(erro =>{
        if(erro){
            console.log(erro)
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


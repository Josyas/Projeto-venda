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

            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Apagar';
            deleteButton.classList.add('btn', 'btn-danger');
            deleteButton.style.float = 'right';

            const actionsCell = document.createElement('td');
            actionsCell.classList.add('action-buttons');
                        
            actionsCell.appendChild(deleteButton);
            actionsCell.appendChild(editButton);
        
            row.appendChild(actionsCell);
        
            tableBodyElement.appendChild(row);
        }
    })
})
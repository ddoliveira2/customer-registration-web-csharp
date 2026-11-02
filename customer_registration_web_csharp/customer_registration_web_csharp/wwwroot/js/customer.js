function salvar(event) {
    event.preventDefault();

    alert("Cliente salvo com sucesso!");

    // Aqui você poderá integrar com o POST do ASP.NET MVC.
}

function voltar() {
    window.location.href = "/Customer/Index";
}

function sair() {
    window.location.href = "/Account/Logout";
}



function limpar() {
    document.querySelectorAll("#listaClientes tr").forEach(linha => {
        linha.style.display = "";
    });

    document.getElementById("total").textContent = "5";
}

function novoCliente() {
    window.location.href = "/Customer/Create";
}

function editarCliente(id) {
         Swal.fire({
        title: 'Confirma?',
        text: 'Deseja editar este cliente?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33'
    }).then((result) => {

        if (result.isConfirmed) {
            window.location.href = "/Customer/Index?codigo=" + id + "&trigger=edit";
        }

    });
}

function excluirCliente(id) {

     Swal.fire({
        title: 'Confirma a exclusão?',
        text: 'Deseja realmente excluir este cliente?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33'
    }).then((result) => {

        if (result.isConfirmed) {
            window.location.href = "/Customer/Index?codigo=" + id + "&trigger=delete";
        }

    });
}

     
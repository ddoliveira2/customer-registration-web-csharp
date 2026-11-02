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

function pesquisar(event) {
        event.preventDefault();

        const nome = document.getElementById("nome").value.toLowerCase();
        const linhas = document.querySelectorAll("#listaClientes tr");

        let total = 0;

        linhas.forEach(linha => {
            const nomeCliente = linha.cells[1].textContent.toLowerCase();
            const encontrado = nomeCliente.includes(nome);

            linha.style.display = encontrado ? "" : "none";

            if (encontrado) total++;
        });

        document.getElementById("total").textContent = total;
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
    window.location.href = "/Customer/Edit/" + id;
}

function excluirCliente(id) {
    if (confirm("Deseja realmente excluir este cliente?")) {
        window.location.href = "/Customer/Delete/" + id;
    }
}

     
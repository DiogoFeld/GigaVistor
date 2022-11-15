function updateConformidade(id) {

    let responsavelSelect = document.getElementById("responsavel_" + id);//select
    let responsavel = parseInt(responsavelSelect.options[responsavelSelect.selectedIndex].value);

    let atendeSelect = document.getElementById("atende_" + id);//select
    let atende = parseInt(atendeSelect.options[atendeSelect.selectedIndex].value);

    let statusSelect = document.getElementById("status_" + id);//select
    let status = parseInt(statusSelect.options[statusSelect.selectedIndex].value);

    let prazo = document.getElementById("prazo_" + id).value;
    let nConformidade = document.getElementById("nConformidade_" + id).checked;//CheckBox
    let complexidadeNConformidade = document.getElementById("complexidadeNConformidade_" + id).value;

    let explicacaoNConformidade = document.getElementById("explicacaoNConformidade_" + id).value;

    let usuarioNConformidadeSelect = document.getElementById("usuarioNConformidade_" + id);//select
    let usuarioNConformidade = parseInt(usuarioNConformidadeSelect.options[usuarioNConformidadeSelect.selectedIndex].value);

    let statusNConformidadeSelect = document.getElementById("statusNConformidade_" + id);//select
    let statusNConformidade = parseInt(statusNConformidadeSelect.options[statusNConformidadeSelect.selectedIndex].value);

    let dateNConformidade = document.getElementById("dateNConformidade_" + id).value;


    showMessage("carregando");
    $.ajax({
        type: "GET",
        url: "/ItemCheck/uptadeConformidade",
        data: {
            id: id,
            responsavel: responsavel,
            atende: atende,
            status: status,
            prazo: prazo,
            nConformidade: nConformidade,
            complexidadeNConformidade: complexidadeNConformidade,
            explicacaoNConformidade: explicacaoNConformidade,
            usuarioNConformidade: usuarioNConformidade,
            statusNConformidade: statusNConformidade,
            dateNConformidade: dateNConformidade
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
            if (result.responseJSON) {
                alert("Sucesso na atualização");
                hideMessage();
            }
            else
                alert("Falha no atualização");
            hideMessage();
        },
        error: function (response) {

        },
    });

}



function updateCheckList() {
    let checklistTable = document.getElementById("checklistTable");
    let rows = checklistTable.getElementsByTagName("tr");


    let id;

    if (rows.length > 0) {
        showMessage("carregando");
        for (let r in rows) {
            if (typeof rows[r] == 'object') {
                id = rows[r].id;
                updateByid(id);
            }
        }
        alert("Sucesso na atualização");
        hideMessage();

    }
}


function updateByid(id) {
    let responsavelSelect = document.getElementById("responsavel_" + id);//select
    let responsavel = parseInt(responsavelSelect.options[responsavelSelect.selectedIndex].value);

    let atendeSelect = document.getElementById("atende_" + id);//select
    let atende = parseInt(atendeSelect.options[atendeSelect.selectedIndex].value);

    let statusSelect = document.getElementById("status_" + id);//select
    let status = parseInt(statusSelect.options[statusSelect.selectedIndex].value);

    let prazo = document.getElementById("prazo_" + id).value;
    let nConformidade = document.getElementById("nConformidade_" + id).checked;//CheckBox
    let complexidadeNConformidade = document.getElementById("complexidadeNConformidade_" + id).value;

    let explicacaoNConformidade = document.getElementById("explicacaoNConformidade_" + id).value;

    let usuarioNConformidadeSelect = document.getElementById("usuarioNConformidade_" + id);//select
    let usuarioNConformidade = parseInt(usuarioNConformidadeSelect.options[usuarioNConformidadeSelect.selectedIndex].value);

    let statusNConformidadeSelect = document.getElementById("statusNConformidade_" + id);//select
    let statusNConformidade = parseInt(statusNConformidadeSelect.options[statusNConformidadeSelect.selectedIndex].value);

    let dateNConformidade = document.getElementById("dateNConformidade_" + id).value;

    $.ajax({
        type: "GET",
        url: "/ItemCheck/uptadeConformidade",
        data: {
            id: id,
            responsavel: responsavel,
            atende: atende,
            status: status,
            prazo: prazo,
            nConformidade: nConformidade,
            complexidadeNConformidade: complexidadeNConformidade,
            explicacaoNConformidade: explicacaoNConformidade,
            usuarioNConformidade: usuarioNConformidade,
            statusNConformidade: statusNConformidade,
            dateNConformidade: dateNConformidade
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {

        },
        error: function (response) {

        },
    });

}

function updatePosConformidade(id) {

    let responsavelSelect = document.getElementById("responsavel_" + id);
    let responsavel = parseInt(responsavelSelect.options[responsavelSelect.selectedIndex].value);

    let explicacao = document.getElementById("explicacao_" + id).value;

    let complexidadeNConformidadeSelect = document.getElementById("complexidadeNConformidade_" + id);
    let complexidadeNConformidade = parseInt(complexidadeNConformidadeSelect.options[complexidadeNConformidadeSelect.selectedIndex].value);

    let statusNConformidadeSelect = document.getElementById("statusNConformidade_" + id);
    let statusNConformidade = parseInt(statusNConformidadeSelect.options[statusNConformidadeSelect.selectedIndex].value);

    let statusSelect = document.getElementById("status_" + id);
    let status = parseInt(statusSelect.options[statusSelect.selectedIndex].value);

    let prazoCumprido = document.getElementById("prazoCumprido_" + id).checked;//checkbox

    let statusPosNConformidadeSelect = document.getElementById("statusPosNConformidade_" + id);
    let statusPosNConformidade = parseInt(statusPosNConformidadeSelect.options[statusPosNConformidadeSelect.selectedIndex].value);

    let prazoPos = document.getElementById("prazoPos_" + id).value;

    let usuarioNConformidadeSelect = document.getElementById("usuarioNConformidade_" + id);
    let usuarioNConformidade = parseInt(usuarioNConformidadeSelect.options[usuarioNConformidadeSelect.selectedIndex].value);


    showMessage("carregando");
    //update conformidade
    $.ajax({
        type: "GET",
        url: "/NaoConformidade/updateConformidade",
        data: {
            id: id,
            responsavel: responsavel,
            explicacao: explicacao,
            complexidadeNConformidade: complexidadeNConformidade,
            statusNConformidade: statusNConformidade,
            status: status,
            prazoCumprido: prazoCumprido,
            statusPosNConformidade: statusPosNConformidade,
            prazoPos: prazoPos,
            usuarioNConformidade: usuarioNConformidade
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
            if (result.responseJSON) {
                alert("Sucesso na atualização");
                window.location.reload();
            }
            else
                alert("Falha na atualização");

            hideMessage();
        },
        error: function (response) {

        },
    });
}

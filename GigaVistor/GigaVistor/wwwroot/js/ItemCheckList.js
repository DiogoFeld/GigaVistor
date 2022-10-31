function addItemToList() {
    let checklistTable = document.getElementById("checklistTable");

    let newRow = document.createElement("tr");
    newRow.setAttribute("tipo", "newRow");
    checklistTable.appendChild(newRow);

    let descriptionTd = document.createElement("td");
    newRow.appendChild(descriptionTd);
    let inputDescription = document.createElement("input");
    inputDescription.setAttribute("tipo", "descricao");
    descriptionTd.appendChild(inputDescription);


    let responsavelTd = document.createElement("td");
    newRow.appendChild(responsavelTd);
    let inputResponsavel = selectorGetUser(responsavelTd);
    inputResponsavel.setAttribute("tipo", "responsavel");
    inputResponsavel.hidden = false;
    inputResponsavel.readOnly = true;

    let aderenteTd = document.createElement("td");
    newRow.appendChild(aderenteTd);
    let selectAderente = addSelectionAtendStatus(aderenteTd)
    selectAderente.setAttribute("tipo", "aderente");

    let statusTd = document.createElement("td");
    newRow.appendChild(statusTd);
    let selectAderent = addSelectionAtend(statusTd);
    selectAderent.setAttribute("tipo", "status");
    selectAderent.selectedIndex = 0;
    selectAderent.readOnly = true;

    let prazoTd = document.createElement("td");
    newRow.appendChild(prazoTd);
    let prazoInput = document.createElement("input");
    prazoInput.setAttribute("tipo", "Prazo");
    prazoInput.type = "date";
    prazoTd.appendChild(prazoInput);

    let NCTd = document.createElement("td");
    newRow.appendChild(NCTd);
    let NCTInput = document.createElement("input");
    NCTInput.setAttribute("tipo", "NCBool");
    NCTInput.type = "checkbox";
    NCTInput.className = "checkBoxList";
    NCTd.appendChild(NCTInput);

    let seriedadeNCTd = document.createElement("td");
    newRow.appendChild(seriedadeNCTd);
    let selectSeriedade = addSelectionClassificationNCF(seriedadeNCTd);
    selectSeriedade.setAttribute("tipo", "NCSeriedade");
    selectSeriedade.selectedIndex = 0;
    selectSeriedade.ariaReadOnly;

    let descricaoNCTd = document.createElement("td");
    newRow.appendChild(descricaoNCTd);
    let descricaoInput = document.createElement("input");
    descricaoInput.setAttribute("tipo", "NCDescricao");
    descricaoInput.value = "-";
    descricaoInput.readOnly = true;
    descricaoNCTd.appendChild(descricaoInput);

    let statusPosResponsavelNCTd = document.createElement("td");
    newRow.appendChild(statusPosResponsavelNCTd);
    let statusPosNC = selectorGetUser(statusPosResponsavelNCTd);
    statusPosNC.setAttribute("tipo", "NCStatusResponsavel");
    statusPosNC.selectedIndex = 0;
    statusPosNC.readOnly = true;

    let statusNCTd = document.createElement("td");
    newRow.appendChild(statusNCTd);
    let inputStatysNC = addSelectionAtendStatus(statusNCTd);
    inputStatysNC.setAttribute("tipo", "NCStatus");
    inputStatysNC.readOnly = true;
    inputStatysNC.selectedIndex = 0;

    let prazoNCTd = document.createElement("td");
    newRow.appendChild(prazoNCTd);
    let prazoNCInput = document.createElement("input");
    prazoNCInput.setAttribute("tipo", "NCPrazo");
    prazoNCInput.readOnly = true;
    prazoNCInput.type = "date";
    prazoNCTd.appendChild(prazoNCInput);

    let buttonAddNCTd = document.createElement("td");
    newRow.appendChild(buttonAddNCTd);
    let buttonAddNCButton = document.createElement("button");
    buttonAddNCButton.setAttribute("tipo", "NCbutton");
    buttonAddNCTd.appendChild(buttonAddNCButton);
    buttonAddNCButton.style.display = "none";
}

function addSelectionAtend(parentElement) {
    let select = document.createElement("select");
    select.disabled = true;

    let option1 = document.createElement("option");
    option1.innerHTML = "Não";
    option1.value = 0;
    let option2 = document.createElement("option");
    option2.innerHTML = "Sim";
    option2.value = 1;
    let option3 = document.createElement("option");
    option3.innerHTML = "Não se Aplica";
    option3.value = 2;

    select.appendChild(option1);
    select.appendChild(option2);
    select.appendChild(option3);

    parentElement.appendChild(select);
    return select;
}

function addSelectionStatus(parentElement) {
    let select = document.createElement("select");
    select.disabled = true;

    let option1 = document.createElement("option");
    option1.innerHTML = "Pendente";
    option1.value = 0;
    let option2 = document.createElement("option");
    option2.innerHTML = "Em andamento";
    option2.value = 1;
    let option3 = document.createElement("option");
    option3.innerHTML = "Concluído";
    option3.value = 2;

    select.appendChild(option1);
    select.appendChild(option2);
    select.appendChild(option3);

    parentElement.appendChild(select);
    return select;
}


function addSelectionClassificationNCF(parentElement) {
    let select = document.createElement("select");
    select.disabled = true;

    let option1 = document.createElement("option");
    option1.innerHTML = "Baixa";
    option1.value = 0;
    let option2 = document.createElement("option");
    option2.innerHTML = "Média";
    option2.value = 1;
    let option3 = document.createElement("option");
    option3.innerHTML = "Alta";
    option3.value = 2;

    select.appendChild(option1);
    select.appendChild(option2);
    select.appendChild(option3);

    parentElement.appendChild(select);
    return select;
}

function addSelectionAtendStatus(parentElement) {
    let select = document.createElement("select");
    select.disabled = true;

    let option1 = document.createElement("option");
    option1.innerHTML = "Não";
    option1.value = 0;
    let option2 = document.createElement("option");
    option2.innerHTML = "Sim";
    option2.value = 1;

    select.appendChild(option1);
    select.appendChild(option2);

    parentElement.appendChild(select);
    return select;
}

function selectorGetUser(parentElement) {
    let selectUsers = document.getElementById("selectUsers");

    let newSelect = selectUsers.cloneNode(true);
    parentElement.appendChild(newSelect);

    return newSelect;
}

function SendList() {
    showMessage("Carregando");

    let checkListId = document.getElementById("idCheckList").value;
    let checklistTable = document.getElementById("checklistTable");
    let rows = checklistTable.getElementsByTagName("tr");

    let descricoes = "";
    let responsaveis = "";
    let prazos = "";
    let escalonamentoResponsaveis = "";

    let descricao;
    let responsavel;
    let prazo;
    let escalonamentoResponsavel;

    for (let r in rows) {
        if (typeof rows[r] == 'object') {
            let checkListItem = {};
            checkListItem.Id = 0;
            descricao = rows[r].querySelectorAll("[tipo='descricao']")[0].value;
            descricoes += descricao + "//";

            responsavel = rows[r].querySelectorAll("[tipo='responsavel']")[0].value;
            responsaveis += responsavel + "//";
            
            prazo = rows[r].querySelectorAll("[tipo='Prazo']")[0].value;
            prazos += prazo + "//";
                        
            escalonamentoResponsavel = rows[r].querySelectorAll("[tipo='NCStatusResponsavel']")[0].value;
            escalonamentoResponsaveis += escalonamentoResponsavel + "//";
        }
    }

    $.ajax({
        type: "GET",
        url: "/Checklist/AddNewItens",
        data: {
            descricoes: descricoes,
            responsaveis :responsaveis,
            prazos :prazos,
            escalonamentoResponsaveis: escalonamentoResponsaveis,
            idCheckList: checkListId
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
        },
        error: function (response) {
        },
    });
    hideMessage();
}

function showMessage(message) {
    let divLabelInfo = document.getElementById("divLabelInfo");
    divLabelInfo.hidden = false;

    let labelInfo = document.getElementById("labelInfo");
    labelInfo.innerHTML = message;
}

function hideMessage() {
    let divLabelInfo = document.getElementById("divLabelInfo");
    divLabelInfo.hidden = true;
}
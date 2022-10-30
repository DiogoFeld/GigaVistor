function addItemToList() {
    let checklistTable = document.getElementById("checklistTable");

    let newRow = document.createElement("tr");
    checklistTable.appendChild(newRow);

    let descriptionTd = document.createElement("td");
    newRow.appendChild(descriptionTd);


    let responsavelTd = document.createElement("td");
    newRow.appendChild(responsavelTd);

    let aderenteTd = document.createElement("td");
    newRow.appendChild(aderenteTd);

    let statusTd = document.createElement("td");
    newRow.appendChild(statusTd);

    let prazoTd = document.createElement("td");
    newRow.appendChild(prazoTd);

    let NCTd = document.createElement("td");
    newRow.appendChild(NCTd);

    let seriedadeNCTd = document.createElement("td");
    newRow.appendChild(seriedadeNCTd);

    let descricaoNCTd = document.createElement("td");
    newRow.appendChild(descricaoNCTd);

    let statusPosNCTd = document.createElement("td");
    newRow.appendChild(statusPosNCTd);

    let prazoNCTd = document.createElement("td");
    newRow.appendChild(prazoNCTd);

    let buttonAddNCTd = document.createElement("td");
    newRow.appendChild(buttonAddNCTd);

}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function showTemplate() {
    let templateDiv = document.getElementById("templateDiv");
    if (templateDiv.hidden == true) {
        templateDiv.hidden = false;
        loadtemplates();
    }
    else {
        templateDiv.hidden = true;
    }
}

function loadtemplates() {

    let templateMain = document.getElementById("Templates")

    clearDiv(templateMain);

    $.ajax({
        type: "GET",
        url: "/Template/getTemplates",
        data: {

        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
            let json = result.responseJSON
            for (let i in json) {
                json[i];
                let divTemplate = document.createElement("div");
                divTemplate.className = "mainElementSelection";
                templateMain.appendChild(divTemplate)

                let title = document.createElement("h3");
                title.className = "titleSection";
                title.innerHTML = json[i].name;
                divTemplate.appendChild(title);

                let spanDescri = document.createElement("span");
                spanDescri.className = "auditoriaSection";
                spanDescri.innerHTML = json[i].description;
                divTemplate.appendChild(spanDescri);

                let divSelector = document.createElement("div");
                divSelector.className = "mainElementFooter";
                divTemplate.appendChild(divSelector);

                let button = document.createElement("button");
                button.innerHTML = "Selecionar";
                button.className = "btn buttonFooterElement";
                button.onclick = function () { loadTasks(json[i].id) };
                divSelector.appendChild(button);
                //add onclickFunction
            }
        },
        error: function (response) {

        },
    });
}


function clearDiv(element) {
    while (element.childNodes.length > 1) {
        element.removeChild(element.childNodes(element.childNodes.length - 1));
    }
}

function loadTasks(id) {
    let TemplatesTarefas = document.getElementById("TemplatesTarefas");
    clearDiv(TemplatesTarefas);

    $.ajax({
        type: "GET",
        url: "/Tarefatemplate/getTarefa",
        data: {
            id: id
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
            let json = result.responseJSON
            for (let i in json) {
                let mainDiv = document.createElement("div");
                mainDiv.className = "mainElementSelection";
                mainDiv.style.width = "180px";
                TemplatesTarefas.appendChild(mainDiv);

                let title = document.createElement("h3");
                title.className = "titleSection";
                title.innerHTML = json[i].name;
                mainDiv.appendChild(title);

                let span = document.createElement("span");
                span.className = "auditoriaSection";
                span.innerHTML = json[i].descricao;
                mainDiv.appendChild(span);
            }
        },
        error: function (response) {

        },
    });
}

function TarefaAuditoriaShow(id) {
    console.log("Arriving");
    let statusSelector = document.getElementById("status_" + id);
    let userSelector = document.getElementById("user_" + id);

    let status = parseInt(statusSelector.options[statusSelector.selectedIndex].value);
    let user = parseInt(userSelector.options[userSelector.selectedIndex].value);
    let notes = document.getElementById("notes_" + id).value;


    $.ajax({
        type: "GET",
        url: "/Tarefa/updateTaskShow",
        data: {
            status: status,
            user: user,
            notes: notes,
            id: id
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {

        },
        error: function (response) {

        },
    });
}

function addTarefatemplate() {
    let tarefaTemplateDiv = document.getElementById("TarefaTemplateDiv");

    let mainDiv = document.createElement("div");
    mainDiv.setAttribute("tipo", "tarefaTemplate");
    mainDiv.className = "mainElementSelection";
    mainDiv.style.height = "180px";
    tarefaTemplateDiv.appendChild(mainDiv);

    let title = document.createElement("input");
    title.placeholder = "Nome";
    title.setAttribute("tipo", "tarefaNome");
    title.className = "titleSection inputTarefaTemplateT";
    mainDiv.appendChild(title);

    let span = document.createElement("input");
    span.placeholder = "descricao";
    span.className = "auditoriaSection inputTarefaTemplateDesc";
    span.setAttribute("tipo", "tarefaDescricao");
    mainDiv.appendChild(span);


    let div = document.createElement("div");
    div.className = "centerIten";
    mainDiv.appendChild(div);

    let i = document.createElement("i");
    i.className = "fas fa-solid fa-trash";
    i.onclick = function () { deleteTaskTemplate(i) }
    div.appendChild(i);

    tarefaTemplateDiv.appendChild(mainDiv);
}

function deleteTaskTemplate(element) {
    let parentElement = element.parentElement.parentElement;
    parentElement.remove();
}

function createTemplateImport() {
    let nomeTemplate = document.getElementById("templateName").value;
    let descrTemplate = document.getElementById("templateDescript").value;

    let stringNames = '';
    let stringDescritis = '';

    let tasks = document.querySelectorAll("[tipo='tarefaTemplate']");
    for (let task in tasks) {
        if (typeof tasks[task] === 'object') {

            let name = tasks[task].getElementsByTagName("input")[0].value;
            let descric = tasks[task].getElementsByTagName("input")[1].value;


            stringNames += name + "//";
            stringDescritis += descric + "//";
        }
    }

    $.ajax({
        type: "GET",
        url: "/Template/CreateTemplateExport",
        data: {
            nome: nomeTemplate,
            descricao: descrTemplate,
            listNames: stringNames,
            listDescription: stringDescritis
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {


        },
        error: function (response) {

        },
    });
}

function selectTemplate(id) {
    let templateId = document.getElementById("tarefasTemplate");
    templateId.hidden = false;

    let templateDiv = document.getElementById("tarefasTemplateDiv");
    templateDiv.innerHTML = "";

    setTimeout(() => {
        LoadTarefaTemplate(id, templateDiv);
    }, "200");
}


function LoadTarefaTemplate(id, templateDiv) {
    $.ajax({
        type: "GET",
        url: "/TarefaTemplate/getTarefaForImport",
        data: {
            id: id
        },
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        complete: function (result) {
            console.log(result);
            let resultJson = result.responseJSON;
            let tarefas = resultJson.tarefas;
            let users = resultJson.users;
            let setores = resultJson.setores;
            users = users.filter(noAdmin);

            for (let t in tarefas) {
                let divTarefa = document.createElement("div");
                divTarefa.setAttribute("tipo", "tarefaTemplate");
                divTarefa.id = tarefas[t].id;
                divTarefa.className = "mainElementSelection taskShow";
                divTarefa.style.height = "400px";
                templateDiv.appendChild(divTarefa);

                let title = document.createElement("h3");
                title.className = "titleSection";
                title.innerHTML = tarefas[t].name;
                title.id = "nome_" + tarefas[t].id;
                divTarefa.setAttribute("tipo", "tarefaTemplate");
                divTarefa.appendChild(title);

                //descr
                let divDescr = document.createElement("div");
                divDescr.className = "taskDescripField";
                divTarefa.appendChild(divDescr);

                let p = document.createElement("p");
                p.innerHTML = "Descrição da Tarefa:";
                divDescr.appendChild(p);

                let span = document.createElement("span");
                span.className = "auditoriaSection";
                span.innerHTML = tarefas[t].descricao;
                span.id = "descricao_" + tarefas[t].id;
                divDescr.appendChild(span);

                //user
                let divUser = document.createElement("div");
                divUser.className = "taskResponsiblebutton";
                divTarefa.appendChild(divUser);

                let p2 = document.createElement("p");
                p2.innerHTML = "Responsável :";
                divUser.appendChild(p2);

                let selectorUser = document.createElement("select");
                selectorUser.id = "user_" + tarefas[t].id;

                for (let u in users) {
                    let optionUser = document.createElement("option");
                    optionUser.innerHTML = users[u].nome;
                    optionUser.value = users[u].id;
                    selectorUser.appendChild(optionUser);
                }
                divUser.appendChild(selectorUser);

                //setor
                let divSetor = document.createElement("div");
                divSetor.className = "taskResponsiblebutton";
                divTarefa.appendChild(divSetor);

                let p3 = document.createElement("p");
                p3.innerHTML = "Setor :";
                divSetor.appendChild(p3);

                let selectorSetor = document.createElement("select");
                selectorSetor.id = "setor_" + tarefas[t].id;

                for (let s in setores) {
                    let optionSetor = document.createElement("option");
                    optionSetor.innerHTML = setores[s].nome;
                    optionSetor.value = setores[s].id;
                    selectorSetor.appendChild(optionSetor);
                }
                divSetor.appendChild(selectorSetor);
            }
        },
        error: function (response) {

        },
    });
}


function noAdmin(entry) {
    return entry.nome != "Admin";
}

function CreateAudiriaByTemplate() {

    let nomeAuditoria = document.getElementById("idNome").value;
    let descricAditoria = document.getElementById("idDescri").value;
    let projetoId = document.getElementById("idProjeto").value;

    let result = true;

    if (nome != "" || nome == null) {
        result = false;
        alert("insira um nome");
    }
    if (descric != "" || descric == null) {
        result = false;
        alert("insira uma descrição");
    }

    if (result) {
        let stringNames = "";
        let stringDescricoes = "";
        let stringResponsaveis = "";
        let stringSetores = "";

        let name = "";
        let descri = "";

        let responsavel = "";;
        let responsavelSelect;

        let setor = "";
        let setorSelect;

        let tasks = document.querySelectorAll("[tipo='tarefaTemplate']");

        for (let task in tasks) {
            if (typeof tasks[task] === 'object') {
                let idTask = tasks[task].id;

                if (idTask != "") {
                    name += document.getElementById("nome_" + idTask).innerHTML + "//";
                    descri += document.getElementById("descricao_" + idTask).innerHTML + "//";

                    responsavelSelect = document.getElementById("user_" + idTask);
                    responsavel += responsavelSelect.options[responsavelSelect.selectedIndex].value + "//";

                    setorSelect = document.getElementById("setor_" + idTask);
                    setor += setorSelect.options[setorSelect.selectedIndex].value + "//";
                }
            }
        }

        if (name != "") {
            $.ajax({
                type: "GET",
                url: "/Auditoria/CreateAuditoriaByTemplate",
                data: {
                    nameAuditoria: nomeAuditoria,
                    idProjeto: projetoId,
                    descricAuditoria: descricAditoria,
                    listNames: name,
                    listDescric: descri,
                    listReponsavel: responsavel,
                    listSetores: setor
                },
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                complete: function (result) {

                },
                error: function (response) {

                },
            });
        }
        else {
            alert("Escolha algum template");
        }
    }
    else {
        alert("preencha todos os campos de Auditoria")
    }
}

function SendEmail(id) {
    if (id != null) {
        let selector = document.getElementById("user_" + id);
        let userId = selector.options[selector.selectedIndex].value;

        let emailTitle = document.getElementById("emailTitle").value;
        let emailDescrip = document.getElementById("emailDescrip").value;

        $.ajax({
            type: "GET",
            url: "/Auditoria/SendEmail",
            data: {
                body: emailDescrip,
                idUser: userId,
                header: emailTitle
            },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            complete: function (result) {
                if (result.responseJSON) {
                    closeEmail();
                    alert("Sucesso no envio");
                }
                else
                    alert("Falha no envio");
            },
            error: function (response) {

            },
        });
    }
}

function ShowEmail(id) {
    let emailDiv = document.getElementById("emailDiv");
    let emailSender = document.getElementById("emailSender");

    //improve email Div
    let selectorUser = document.getElementById("user_" + id);
    let name = selectorUser.options[selectorUser.selectedIndex].innerHTML;
    document.getElementById("userEmail").innerHTML = name;

    let nameTask = document.getElementById("name_" + id).innerHTML;
    document.getElementById("taskEmail").innerHTML = nameTask;

    emailSender.onclick = function () { SendEmail(id) };
    emailDiv.hidden = false;
}

function closeEmail() {
    document.getElementById("emailTitle").value = "";
    document.getElementById("emailDescrip").value = "";

    document.getElementById("userEmail").innerHTML = "";
    document.getElementById("taskEmail").innerHTML = "";

    let emailDiv = document.getElementById("emailDiv");
    emailDiv.hidden = true;
}


function changeUserCreate(element) {
    
    let superVisorId = document.getElementById("superVisorId");
    superVisorId.value = parseInt(element.value);

}
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
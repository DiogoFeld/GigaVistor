using GigaVistor.Models;
using GigaVistor.Services.ChecklistService;
using GigaVistor.Services.NaoConformidadeService;
using GigaVistor.Services.TarefaTemplateServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GigaVistor.Controllers
{
    public class NaoConformidadeController : Controller
    {

        INaoConformidadeService nConformidade;
        public NaoConformidadeController(INaoConformidadeService _nConformidade)
        {            
            nConformidade = _nConformidade;
        }


        public IActionResult naoConformidade(int id)
        {            
            ViewBag.checklist = nConformidade.getItemChecklist(id).IdCheckList;
            ViewBag.Usuarios = nConformidade.GetUsers();
            ViewBag.idNaoConformidade = id;

            IEnumerable <NaoConformidadeModel> conformidades = nConformidade.getConformidadesByTarefa(id);
            return View(conformidades);
        }

        public JsonResult updateConformidade(string id,string responsavel,string explicacao,string complexidadeNConformidade,
            string statusNConformidade,string status,string prazoCumprido,string statusPosNConformidade,string prazoPos,
            string usuarioNConformidade)
        {
            NaoConformidadeModel naoConformidade = new NaoConformidadeModel
            {
                Id = int.Parse(id),
                IdResponsavel = int.Parse(responsavel),
                Explicação = explicacao,
                Classificao = int.Parse(complexidadeNConformidade),
                PrazoResolucao = int.Parse(statusNConformidade),
                Status = int.Parse(status),
                PrazoCumprido = bool.Parse(prazoCumprido),//checa pra ver se ja foi escalonada pra outra pessoa
                StatusPosEscalonamento = int.Parse(statusPosNConformidade),
                DatePrazoEscalonado = DateTime.Parse(prazoPos),
                IdEscalonamentoResponsavel = int.Parse(usuarioNConformidade)
            };
            //send to service to update
            bool resultConformidade = nConformidade.updateNaoConformidade(naoConformidade);

            return Json(resultConformidade);
        }



    }
}

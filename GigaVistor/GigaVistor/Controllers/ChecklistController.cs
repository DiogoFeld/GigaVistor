using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.AuditoriaServices;
using GigaVistor.Services.ChecklistService;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ChecklistController : Controller
    {

        ICheckListService checkListService;
        public ChecklistController(ICheckListService _checkListService)
        {
            checkListService = _checkListService;
        }

        public IActionResult Create(long idAuditoria)
        {
            ViewBag.idAuditoria = idAuditoria;
            return View();
        }

        public IActionResult CreateAction(ChecklistModel model)
        {
            bool result = checkListService.CreateAction(model);
            if (result)
            {
                return RedirectToAction("Details", "Auditoria", new { id = (int)model.IdAuditoria });
            }
            else
            {
                return RedirectToAction("Create", new { id = (int)model.IdAuditoria });

            }
        }

        public IActionResult Details(int id)
        {
            ViewBag.Usuarios = checkListService.GetUsers();
            ChecklistModel model = checkListService.GetChecklist(id);

            return View(model);
        }

        public IActionResult Check(int id)
        {
            ChecklistModel model = checkListService.GetChecklist(id);
            return View(model);
        }

        private bool EditChecklist(string name, string descrip)
        {
            bool result = false;

            return result;
        }

        public JsonResult AddNewItens(string descricoes, string responsaveis, string prazos, string escalonamentoResponsaveis, int idCheckList)
        {

            List<ItemCheckModel> itens = new List<ItemCheckModel>();

            string[] descricoesArray = { };
            string[] responsaveisArray = { };
            string[] prazosArray = { };
            string[] escalonamentoResponsaveisArray = { };

            descricoesArray = descricoes.Split("//");
            responsaveisArray = responsaveis.Split("//");
            prazosArray = prazos.Split("//");
            escalonamentoResponsaveisArray = escalonamentoResponsaveis.Split("//");

            for (int i = 0; i < descricoesArray.Length; i++)
            {
                if (descricoesArray[i] != "")
                {

                    ItemCheckModel item = new ItemCheckModel()
                    {
                        Id = 0,
                        Descricao = descricoesArray[i],
                        Aderente = 0,
                        Status = 0,
                        Escalonado = false,
                        ExplicacaoNaoConformidade = "",
                        NaoConformidade = false,
                        NivelNaoConformidade = 0,
                        DateCriacao = DateTime.Now,
                        DatePrazo = DateTime.Parse(prazosArray[i]),
                        DatePrazoEscalonado = DateTime.Now,
                        StatusPosEscalonado = 0,
                        IdCriador = UserDatabase.Instance.getUsuario().Id,
                        IdResponsavel = int.Parse(responsaveisArray[i]),
                        IdCheckList = idCheckList,
                        IdNaoConformidade = int.Parse(escalonamentoResponsaveisArray[i]),

                    };
                    itens.Add(item);
                }
            }
            return Json(new());
        }


    }
}

using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.ChecklistService;
using GigaVistor.Services.ItemCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ItemCheckController : Controller
    {
        IItemCheckService itemCheckServicecheckListService;
        public ItemCheckController(IItemCheckService _itemCheckServicecheckListService)
        {
            itemCheckServicecheckListService = _itemCheckServicecheckListService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public bool addIten(IEnumerable<ItemCheckModel> itens)
        {
            itemCheckServicecheckListService.addNewIten(itens);
            
            return false;
        }

        public JsonResult AddNewItens(string descricoes, string responsaveis, string prazos, string escalonamentoResponsaveis, string idCheckList)
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
                        IdCheckList = int.Parse(idCheckList),
                        IdNaoConformidade = int.Parse(escalonamentoResponsaveisArray[i]),

                    };
                    itens.Add(item);
                }
            }
            bool result = addIten(itens);

            return Json(result);
        }

    }
}

using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.ChecklistService;
using GigaVistor.Services.ItemCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ItemCheckController : Controller
    {
        IItemCheckService itemCheckServiceCheckListService;
        public ItemCheckController(IItemCheckService _itemCheckServicecheckListService)
        {
            itemCheckServiceCheckListService = _itemCheckServicecheckListService;
        }


        public IActionResult Index()
        {
            ViewBag.Itens = itemCheckServiceCheckListService.GetItens();
            return View();
        }

        public bool addIten(ItemCheckModel iten)
        {
            itemCheckServiceCheckListService.addIten(iten);

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
                        IdNaoConformidade = 0,
                    };
                    addIten(item);
                    itens.Add(item);
                }
            }
            return Json(itens);
        }

        public JsonResult uptadeConformidade(string id, string responsavel, string atende, string status, string prazo, string nConformidade, string complexidadeNConformidade,
            string explicacaoNConformidade, string usuarioNConformidade, string statusNConformidade, string dateNConformidade)
        {
            bool result = false;

            ItemCheckModel conformidade = new ItemCheckModel()
            {
                Id = long.Parse(id),
                Aderente = int.Parse(atende),
                Status = int.Parse(status),
                Escalonado = bool.Parse(nConformidade),
                ExplicacaoNaoConformidade = explicacaoNConformidade,
                NaoConformidade = bool.Parse(nConformidade),
                NivelNaoConformidade = int.Parse(complexidadeNConformidade),
                DatePrazo = DateTime.Parse(prazo),
                DatePrazoEscalonado = DateTime.Parse(dateNConformidade),
                StatusPosEscalonado = int.Parse(statusNConformidade),
                IdResponsavel = int.Parse(responsavel),
                IdNaoConformidadeResponsavel = int.Parse(usuarioNConformidade),
            };

            result = itemCheckServiceCheckListService.updateConformidade(conformidade);

            bool naoConformidadeResult = false;
            if (conformidade.NaoConformidade)
            {               
                naoConformidadeResult = itemCheckServiceCheckListService.getNaoConformidade(conformidade.Id);                
            }
            if (naoConformidadeResult)
            {
                itemCheckServiceCheckListService.CreateNaoConformidade(conformidade.Id);

                //crete NaoConformidade // pegar os detalhes da tarefa
            }
            return Json(result);
        }






    }
}

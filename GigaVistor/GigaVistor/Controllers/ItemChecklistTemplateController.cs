using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Models;
using GigaVistor.Services.ItemChecklistTemplateService;
using GigaVistor.Services.ItemCheckServices;
using Microsoft.AspNetCore.Mvc;

namespace GigaVistor.Controllers
{
    public class ItemChecklistTemplateController : Controller
    {
     
        IItemChecklistTemplateService itemChecklistTemplateService;
        public ItemChecklistTemplateController(IItemChecklistTemplateService _itemChecklistTemplateService)
        {
            itemChecklistTemplateService = _itemChecklistTemplateService;
        }      
        public JsonResult AddDescricoes(string conformidades, string checkListId)
        {
            bool result = false;
            int checkListInt = int.Parse(checkListId);


            if (conformidades != null)
            {
                string[] descricoesArray = conformidades.Split("//");
                foreach (string s in descricoesArray)
                {
                    if (s != "")
                    {
                        ItemChecklistTemplateModel item = new ItemChecklistTemplateModel()
                        {
                            Descricao = s,
                            IdCheckList = checkListInt,
                            DateCriacao = DateTime.Now,
                            IdCriador = UserDatabase.Instance.getUsuario().Id
                        };
                        itemChecklistTemplateService.addIten(item);
                        
                    }
                }
            }
            return Json(result);
        }

    }
}

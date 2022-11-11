using GigaVistor.Data;
using GigaVistor.Models;
using System.Drawing;
using System.Linq;

namespace GigaVistor.Services.ItemCheckServices
{
    public class ItemCheckService : IItemCheckService
    {
        GigaVistorContext db;
        public ItemCheckService(GigaVistorContext _db)
        {
            db = _db;
        }

        public IEnumerable<ItemChecklistTemplateModel> GetItens()
        {
            IEnumerable<ItemChecklistTemplateModel> checklistTemplateItens = db.itemCheckListTemplates.Select(s => s).ToList();
            return checklistTemplateItens;
        }

        public bool addList(IEnumerable<ItemCheckModel> itens)
        {
            try
            {
                foreach (ItemCheckModel itemCheck in itens)
                {
                    db.itensCheckList.Add(itemCheck);
                }
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool addIten(ItemCheckModel item)
        {
            try
            {
                db.itensCheckList.Add(item);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool updateConformidade(ItemCheckModel _conformidade)
        {
            try
            {
                ItemCheckModel conformidade = db.itensCheckList.FirstOrDefault(s => s.Id == _conformidade.Id);

                conformidade.Aderente = _conformidade.Aderente;
                conformidade.Status = _conformidade.Status;
                conformidade.Escalonado = _conformidade.Escalonado;
                conformidade.ExplicacaoNaoConformidade = _conformidade.ExplicacaoNaoConformidade != null ? _conformidade.ExplicacaoNaoConformidade: " ";
                conformidade.NaoConformidade = _conformidade.NaoConformidade;
                conformidade.NivelNaoConformidade = _conformidade.NivelNaoConformidade;
                conformidade.DatePrazo = _conformidade.DatePrazo;
                conformidade.DatePrazoEscalonado = _conformidade.DatePrazoEscalonado;
                conformidade.StatusPosEscalonado = _conformidade.StatusPosEscalonado;
                conformidade.IdResponsavel = _conformidade.IdResponsavel;
                conformidade.IdNaoConformidade = _conformidade.IdNaoConformidade;

                db.SaveChanges();

                return true;
            }
            catch
            {

            }
            return false;
        }


    }
}

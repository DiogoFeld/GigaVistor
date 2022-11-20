using GigaVistor.Controllers;
using GigaVistor.Controllers.DatabaseSingleton;
using GigaVistor.Data;
using GigaVistor.Models;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

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
                conformidade.ExplicacaoNaoConformidade = _conformidade.ExplicacaoNaoConformidade != null ? _conformidade.ExplicacaoNaoConformidade : " ";
                conformidade.NaoConformidade = _conformidade.NaoConformidade;
                conformidade.NivelNaoConformidade = _conformidade.NivelNaoConformidade;
                conformidade.DatePrazo = _conformidade.DatePrazo;
                conformidade.DatePrazoEscalonado = _conformidade.DatePrazoEscalonado;
                conformidade.StatusPosEscalonado = _conformidade.StatusPosEscalonado;
                conformidade.IdResponsavel = _conformidade.IdResponsavel;
                conformidade.IdNaoConformidadeResponsavel = _conformidade.IdNaoConformidadeResponsavel;

                db.SaveChanges();

                return true;
            }
            catch
            {

            }
            return false;
        }

        public bool getNaoConformidade(long id)
        {
            bool result = false;
            NaoConformidadeModel model = new NaoConformidadeModel();
            try
            {
                model = db.naoConformidades.FirstOrDefault(s => s.IdTarefa == id);

                if (model == null)
                {
                    result = true;
                }
            }
            catch { }
            return result;
        }

        public void CreateNaoConformidade(long id)
        {
            //meake new one and update the value of idNConformidade
            try
            {
                ItemCheckModel conformidade = db.itensCheckList.FirstOrDefault(s => s.Id == id);
                if (conformidade.IdNaoConformidade == 0)
                {
                    NaoConformidadeModel naoConformidadeModel = new NaoConformidadeModel
                    {
                        DateCriacao = DateTime.Now,
                        IdCriador = UserDatabase.Instance.getUsuario().Id,
                        Descricao = conformidade.Descricao,
                        Explicação = conformidade.ExplicacaoNaoConformidade,
                        Classificao = conformidade.NivelNaoConformidade,
                        DatePrazoEscalonado = conformidade.DatePrazoEscalonado,
                        Aderente = 0,
                        Status = 0,
                        StatusPosEscalonamento = 0,
                        DatePrazo = conformidade.DatePrazoEscalonado,
                        PrazoCumprido = false,
                        PrazoEscalonadoCumprido = false,
                        IdEscalonamentoResponsavel = (int)conformidade.IdNaoConformidadeResponsavel,
                        StatusPosEscalonado = 0,
                        IdEscalonamento = (int)conformidade.IdNaoConformidadeResponsavel,
                        IdResponsavel = (int)conformidade.IdNaoConformidadeResponsavel,
                        IdCheckList = (int)conformidade.IdCheckList,
                        IdTarefa = (int)conformidade.Id,
                    };

                    db.naoConformidades.Add(naoConformidadeModel);
                    db.SaveChanges();

                    conformidade.IdNaoConformidade = naoConformidadeModel.Id;
                    db.SaveChanges();
                }
            }
            catch { }
        }



    }
}

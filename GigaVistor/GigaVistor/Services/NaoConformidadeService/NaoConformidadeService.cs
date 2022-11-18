using GigaVistor.Data;
using GigaVistor.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GigaVistor.Services.NaoConformidadeService
{
    public class NaoConformidadeService : INaoConformidadeService
    {

        GigaVistorContext db;
        public NaoConformidadeService(GigaVistorContext _db)
        {
            db = _db;
        }

        public IEnumerable<NaoConformidadeModel> getAllNaoConformidades()
        {
            IEnumerable<NaoConformidadeModel> conformidades = db.naoConformidades.Select(s => s).ToList();
            return conformidades;
        }


        public IEnumerable<NaoConformidadeModel> getConformidadesByTarefa(int idTarefa)
        {
            var query = from nComdormidade in db.naoConformidades
                        where nComdormidade.IdTarefa == idTarefa
                        select nComdormidade;

            return query.ToList();
        }

        public IEnumerable<UsuarioModel> GetUsers()
        {
            var query = from usuarios in db.Usuarios
                        where usuarios.Id != 1
                        select usuarios;

            try
            {
                //usuario mestre
                return query.ToList();
            }
            catch
            {
                return query.ToList();
            }
        }

        public bool updateNaoConformidade(NaoConformidadeModel _naoConformidade)
        {
            bool booolResult = false;
            try
            {
                //get original one
                NaoConformidadeModel naoConformidade = db.naoConformidades.FirstOrDefault(s => s.Id == _naoConformidade.Id);

                naoConformidade.IdResponsavel = _naoConformidade.IdResponsavel;
                naoConformidade.Explicação = _naoConformidade.Explicação;
                naoConformidade.Classificao = _naoConformidade.Classificao;
                naoConformidade.PrazoResolucao = _naoConformidade.PrazoResolucao;
                naoConformidade.Status = _naoConformidade.Status;
                naoConformidade.PrazoCumprido = _naoConformidade.PrazoCumprido;
                naoConformidade.StatusPosEscalonamento = _naoConformidade.StatusPosEscalonamento;
                naoConformidade.DatePrazoEscalonado = _naoConformidade.DatePrazoEscalonado;
                naoConformidade.IdEscalonamentoResponsavel = _naoConformidade.IdEscalonamentoResponsavel;


                var result = db.SaveChanges();

                if (result > 0)
                {
                    booolResult = true;

                    if (naoConformidade.PrazoResolucao == 1)
                    {
                        updateTarefaToTrue(naoConformidade.IdTarefa);
                    }
                    else if (naoConformidade.PrazoCumprido)
                    {
                        EscalonarTarefa(naoConformidade);
                    }
                }
                else
                    booolResult = false;

            }
            catch { };
            return booolResult;
        }

        public void updateTarefaToTrue(long idtarefa)
        {
            //update nao conformidade -> uptade escalonada
            try
            {

                IEnumerable<NaoConformidadeModel> conformidades = (from nComdormidade in db.naoConformidades
                                                                   where nComdormidade.IdTarefa == idtarefa
                                                                   select nComdormidade).ToList();

                foreach (NaoConformidadeModel nConformidade in conformidades)
                {
                    nConformidade.StatusPosEscalonamento = 1;
                }

                ItemCheckModel itemCheckModel = db.itensCheckList.FirstOrDefault(s => s.Id == idtarefa);
                itemCheckModel.StatusPosEscalonado = 1;

                db.SaveChanges();
            }
            catch { }
            //update tarefa -> escalonada
        }


        public void EscalonarTarefa(NaoConformidadeModel naoConformidade)
        {
            NaoConformidadeModel newNaoConformidade = new NaoConformidadeModel()
            {
                DateCriacao = DateTime.Now,
                IdCriador = naoConformidade.IdCriador,
                Descricao = naoConformidade.Descricao,
                Explicação = naoConformidade.Explicação,
                Classificao = naoConformidade.Classificao,
                PrazoResolucao = 0,
                Aderente = 0,
                Status = 0,
                StatusPosEscalonamento = 0,
                DatePrazo = naoConformidade.DatePrazoEscalonado,
                PrazoCumprido = false,
                DatePrazoEscalonado = naoConformidade.DatePrazoEscalonado,
                PrazoEscalonadoCumprido = false,
                IdEscalonamentoResponsavel = naoConformidade.IdEscalonamentoResponsavel,
                StatusPosEscalonado = 0,
                NivelEscalonamento = naoConformidade.NivelEscalonamento + 1,//up One lv
                IdEscalonamento = naoConformidade.IdEscalonamento,
                IdResponsavel = naoConformidade.IdEscalonamentoResponsavel,
                IdCheckList = naoConformidade.IdCheckList,
                IdTarefa = naoConformidade.IdTarefa,
            };
            try
            {
                db.naoConformidades.Add(newNaoConformidade);
                db.SaveChanges();
                //save on DV
            }
            catch { }
            //precisa ser escalonado
        }

        public ItemCheckModel getItemChecklist(int id)
        {
            ItemCheckModel itemChecklist = new ItemCheckModel();
            try
            {
                itemChecklist = db.itensCheckList.FirstOrDefault(s => s.Id == id);
            }
            catch { }
            return itemChecklist;
        }


    }
}
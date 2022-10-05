using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.TarefaTemplateServices
{
    public class TarefaTemplateService : ITarefaTemplateService
    {
        GigaVistorContext db;
        public TarefaTemplateService(GigaVistorContext _db)
        {
            db = _db;
        }

        public void Create(TarefaTemplateModel _tarefa)
        {
            if (_tarefa.Id == 0)
            {
                TarefaTemplateModel tarefa = new TarefaTemplateModel();
                tarefa.Name = _tarefa.Name;
                tarefa.Descricao = _tarefa.Descricao;
                tarefa.IdCriador = _tarefa.IdCriador;
                tarefa.IdSetor = _tarefa.IdSetor;
                tarefa.IdAuditoria = _tarefa.IdAuditoria;

                db.TarefasTemplate.Add(tarefa);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            TarefaTemplateModel tarefa = db.TarefasTemplate.FirstOrDefault(s => s.Id == id);
            if (tarefa != null)
            {
                db.Remove(tarefa);
                db.SaveChanges();
            }
        }

        public TarefaTemplateModel DeletePage(int id)
        {
            TarefaTemplateModel tarefa = db.TarefasTemplate.FirstOrDefault(s => s.Id == id);
            return tarefa;
        }

        public void Edit(TarefaTemplateModel _tarefa)
        {
            if (_tarefa != null)
            {
                TarefaTemplateModel tarefa = db.TarefasTemplate.FirstOrDefault(s => s.Id == _tarefa.Id);
                tarefa.Name = _tarefa.Name;
                tarefa.Descricao = _tarefa.Descricao;
                tarefa.IdCriador = _tarefa.IdCriador;
                tarefa.IdSetor = _tarefa.IdSetor;
                tarefa.IdAuditoria = _tarefa.IdAuditoria;

                db.SaveChanges();
            }
        }

        public TarefaTemplateModel EditPage(int id)
        {
            TarefaTemplateModel tarefa = db.TarefasTemplate.FirstOrDefault(s => s.Id == id);
            return tarefa;
        }

        public IEnumerable<TarefaTemplateModel> getAllTarefas()
        {
            IEnumerable<TarefaTemplateModel> tarefas = db.TarefasTemplate.Select(s => s).ToList();
            return tarefas;
        }

        public IEnumerable<TarefaTemplateModel> getAllTarefasByAuditoria(int id)
        {
            var query = from tarefa in db.TarefasTemplate
                        where tarefa.IdAuditoria == id
                        select tarefa;

            return query.ToList();
        }
    }
}

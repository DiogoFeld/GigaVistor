﻿using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Services.TarefaServices
{
    public class TarefaService : ITarefaService
    {
        GigaVistorContext db;
        public TarefaService(GigaVistorContext _db)
        {
            db = _db;
        }


        public void Create(TarefaModel _tarefa)
        {
            if (_tarefa.Id == 0)
            {
                TarefaModel tarefa = new TarefaModel();
                tarefa.Name = _tarefa.Name;
                tarefa.Descricao = _tarefa.Descricao;
                tarefa.IdResponsavel = _tarefa.IdResponsavel;
                tarefa.IdCriador = _tarefa.IdCriador;
                tarefa.IdSetor = _tarefa.IdSetor;
                tarefa.IdAuditoria = _tarefa.IdAuditoria;
                tarefa.Status = _tarefa.Status;
                tarefa.NotasQualidade = _tarefa.NotasQualidade;



                db.Tarefas.Add(tarefa);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            TarefaModel tarefa = db.Tarefas.FirstOrDefault(s => s.Id == id);
            if (tarefa != null)
            {
                db.Remove(tarefa);
                db.SaveChanges();
            }
        }

        public TarefaModel DeletePage(int id)
        {
            TarefaModel tarefa = db.Tarefas.FirstOrDefault(s => s.Id == id);
            return tarefa;
        }

        public void Edit(TarefaModel _tarefa)
        {
            if (_tarefa != null)
            {
                TarefaModel tarefa = db.Tarefas.FirstOrDefault(s => s.Id == _tarefa.Id);                
                tarefa.Name = _tarefa.Name;
                tarefa.Descricao = _tarefa.Descricao;
                tarefa.IdResponsavel = _tarefa.IdResponsavel;
                tarefa.IdCriador = _tarefa.IdCriador;
                tarefa.IdSetor = _tarefa.IdSetor;
                tarefa.IdAuditoria = _tarefa.IdAuditoria;
                tarefa.Status = _tarefa.Status;
                tarefa.NotasQualidade = _tarefa.NotasQualidade;
                
                db.SaveChanges();
            }
        }

        public TarefaModel EditPage(int id)
        {
            TarefaModel tarefa = db.Tarefas.FirstOrDefault(s => s.Id == id);
            return tarefa;            
        }

        public IEnumerable<TarefaModel> getAllTarefas()
        {
            IEnumerable<TarefaModel> tarefas = db.Tarefas.Select(s => s).ToList();
            return tarefas;            
        }


    }
}
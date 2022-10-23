﻿using GigaVistor.Data;
using GigaVistor.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GigaVistor.Services.UsuarioServices
{
    public class UsuarioService : IUsuarioService
    {
        GigaVistorContext db;
        public UsuarioService(GigaVistorContext _db)
        {
            db = _db;
        }
        public void CreateAction(UsuarioModel _usuario)
        {
            if (_usuario.Id == 0)
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.Nome = _usuario.Nome;
                usuario.Setor = _usuario.Setor;
                usuario.Logon = _usuario.Logon;
                usuario.Cargo = _usuario.Cargo;
                usuario.Email = _usuario.Email;
                usuario.IdSuperVisor = getSuperVisorId(_usuario.Setor);
                usuario.Permissao = _usuario.Permissao;


                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        private long getSuperVisorId(string idSetor)
        {

            int idSetorlong = int.Parse(idSetor);

            long result = 0;
            SetorModel setor = db.Setores.FirstOrDefault(s => s.Id == idSetorlong);
            result = setor.SupervisorId;

            return result;
        }
                

        public void DeleteAUsuario(int id)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Id == id);
            if (usuario != null)
            {
                db.Remove(usuario);
                db.SaveChanges();
            }
        }

        public UsuarioModel DeletePage(int id)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Id == id);
            return usuario;
        }

        public UsuarioModel Edit(int id)
        {
            UsuarioModel usuario = db.Usuarios.FirstOrDefault(s => s.Id == id);
            return usuario;
        }

        public void EditAction(UsuarioModel _usuarioModel)
        {
            if (_usuarioModel != null)
            {
                UsuarioModel usuarioModel = db.Usuarios.FirstOrDefault(s => s.Id == _usuarioModel.Id);
                usuarioModel.Nome = _usuarioModel.Nome;
                usuarioModel.Setor = _usuarioModel.Setor;
                usuarioModel.Logon = _usuarioModel.Logon;
                usuarioModel.Cargo = _usuarioModel.Cargo;
                usuarioModel.Email = _usuarioModel.Email;
                usuarioModel.IdSuperVisor = _usuarioModel.IdSuperVisor;
                usuarioModel.Permissao = _usuarioModel.Permissao;

                db.SaveChanges();
            }
        }

        public IEnumerable<UsuarioModel> getAllUsuarios()
        {
            IEnumerable<UsuarioModel> Usuarios = db.Usuarios.Select(s => s).ToList();
            return Usuarios;
        }

    }
}

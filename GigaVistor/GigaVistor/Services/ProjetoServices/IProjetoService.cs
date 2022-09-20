﻿using GigaVistor.Models;

namespace GigaVistor.Services.ProjetoServices
{
    public interface IProjetoService
    {
        public IEnumerable<ProjetoModel> getAllProjetos();
        public void Create(ProjetoModel projeto);
        public void Delete(int id);
        public ProjetoModel DeletePage(int id);
        public void Edit(ProjetoModel projeto);
        public ProjetoModel EditPage(int id);
    }
}

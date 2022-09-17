using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Usuario
{
    public class IndexModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public IndexModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        public IList<UsuarioModel> UsuarioModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Usuarios != null)
            {
                UsuarioModel = await _context.Usuarios.ToListAsync();
            }
        }
    }
}

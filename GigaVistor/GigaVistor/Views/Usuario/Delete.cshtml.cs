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
    public class DeleteModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DeleteModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UsuarioModel UsuarioModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuariomodel = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);

            if (usuariomodel == null)
            {
                return NotFound();
            }
            else 
            {
                UsuarioModel = usuariomodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuariomodel = await _context.Usuarios.FindAsync(id);

            if (usuariomodel != null)
            {
                UsuarioModel = usuariomodel;
                _context.Usuarios.Remove(UsuarioModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Usuario
{
    public class EditModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public EditModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UsuarioModel UsuarioModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuariomodel =  await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuariomodel == null)
            {
                return NotFound();
            }
            UsuarioModel = usuariomodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UsuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(UsuarioModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UsuarioModelExists(long id)
        {
          return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}

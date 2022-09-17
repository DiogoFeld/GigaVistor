using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Auditoria
{
    public class DeleteModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DeleteModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AuditoriaModel AuditoriaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Auditorias == null)
            {
                return NotFound();
            }

            var auditoriamodel = await _context.Auditorias.FirstOrDefaultAsync(m => m.Id == id);

            if (auditoriamodel == null)
            {
                return NotFound();
            }
            else 
            {
                AuditoriaModel = auditoriamodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Auditorias == null)
            {
                return NotFound();
            }
            var auditoriamodel = await _context.Auditorias.FindAsync(id);

            if (auditoriamodel != null)
            {
                AuditoriaModel = auditoriamodel;
                _context.Auditorias.Remove(AuditoriaModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Setor
{
    public class DeleteModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DeleteModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public SetorModel SetorModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Setores == null)
            {
                return NotFound();
            }

            var setormodel = await _context.Setores.FirstOrDefaultAsync(m => m.Id == id);

            if (setormodel == null)
            {
                return NotFound();
            }
            else 
            {
                SetorModel = setormodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Setores == null)
            {
                return NotFound();
            }
            var setormodel = await _context.Setores.FindAsync(id);

            if (setormodel != null)
            {
                SetorModel = setormodel;
                _context.Setores.Remove(SetorModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

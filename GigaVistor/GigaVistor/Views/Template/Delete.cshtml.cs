using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Template
{
    public class DeleteModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DeleteModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TemplateModel TemplateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Templates == null)
            {
                return NotFound();
            }

            var templatemodel = await _context.Templates.FirstOrDefaultAsync(m => m.Id == id);

            if (templatemodel == null)
            {
                return NotFound();
            }
            else 
            {
                TemplateModel = templatemodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Templates == null)
            {
                return NotFound();
            }
            var templatemodel = await _context.Templates.FindAsync(id);

            if (templatemodel != null)
            {
                TemplateModel = templatemodel;
                _context.Templates.Remove(TemplateModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

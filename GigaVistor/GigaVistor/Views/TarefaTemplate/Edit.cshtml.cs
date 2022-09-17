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

namespace GigaVistor.Views.TarefaTemplate
{
    public class EditModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public EditModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TarefaTemplateModel TarefaTemplateModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TarefasTemplate == null)
            {
                return NotFound();
            }

            var tarefatemplatemodel =  await _context.TarefasTemplate.FirstOrDefaultAsync(m => m.Id == id);
            if (tarefatemplatemodel == null)
            {
                return NotFound();
            }
            TarefaTemplateModel = tarefatemplatemodel;
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

            _context.Attach(TarefaTemplateModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaTemplateModelExists(TarefaTemplateModel.Id))
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

        private bool TarefaTemplateModelExists(int id)
        {
          return _context.TarefasTemplate.Any(e => e.Id == id);
        }
    }
}

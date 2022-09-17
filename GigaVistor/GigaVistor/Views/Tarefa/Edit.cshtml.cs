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

namespace GigaVistor.Views.Tarefa
{
    public class EditModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public EditModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TarefaModel TarefaModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefamodel =  await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);
            if (tarefamodel == null)
            {
                return NotFound();
            }
            TarefaModel = tarefamodel;
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

            _context.Attach(TarefaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaModelExists(TarefaModel.Id))
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

        private bool TarefaModelExists(int id)
        {
          return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}

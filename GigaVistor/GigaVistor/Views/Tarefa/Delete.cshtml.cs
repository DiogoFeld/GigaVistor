using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Tarefa
{
    public class DeleteModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DeleteModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TarefaModel TarefaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }

            var tarefamodel = await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);

            if (tarefamodel == null)
            {
                return NotFound();
            }
            else 
            {
                TarefaModel = tarefamodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefamodel = await _context.Tarefas.FindAsync(id);

            if (tarefamodel != null)
            {
                TarefaModel = tarefamodel;
                _context.Tarefas.Remove(TarefaModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

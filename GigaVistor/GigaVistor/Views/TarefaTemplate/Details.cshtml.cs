using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.TarefaTemplate
{
    public class DetailsModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DetailsModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

      public TarefaTemplateModel TarefaTemplateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TarefasTemplate == null)
            {
                return NotFound();
            }

            var tarefatemplatemodel = await _context.TarefasTemplate.FirstOrDefaultAsync(m => m.Id == id);
            if (tarefatemplatemodel == null)
            {
                return NotFound();
            }
            else 
            {
                TarefaTemplateModel = tarefatemplatemodel;
            }
            return Page();
        }
    }
}

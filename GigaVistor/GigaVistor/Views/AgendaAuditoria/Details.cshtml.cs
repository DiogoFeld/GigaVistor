using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.AgendaAuditoria
{
    public class DetailsModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DetailsModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

      public AgendamentoAuditoriaModel AgendamentoAuditoriaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.AgendamentosAuditoria == null)
            {
                return NotFound();
            }

            var agendamentoauditoriamodel = await _context.AgendamentosAuditoria.FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoauditoriamodel == null)
            {
                return NotFound();
            }
            else 
            {
                AgendamentoAuditoriaModel = agendamentoauditoriamodel;
            }
            return Page();
        }
    }
}

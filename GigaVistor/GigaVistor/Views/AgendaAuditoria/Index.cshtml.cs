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
    public class IndexModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public IndexModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        public IList<AgendamentoAuditoriaModel> AgendamentoAuditoriaModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AgendamentosAuditoria != null)
            {
                AgendamentoAuditoriaModel = await _context.AgendamentosAuditoria.ToListAsync();
            }
        }
    }
}

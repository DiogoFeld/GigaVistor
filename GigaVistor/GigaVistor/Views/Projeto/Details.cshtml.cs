using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.Projeto
{
    public class DetailsModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DetailsModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

      public ProjetoModel ProjetoModel { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Projetos == null)
            {
                return NotFound();
            }

            var projetomodel = await _context.Projetos.FirstOrDefaultAsync(m => m.Id == id);
            if (projetomodel == null)
            {
                return NotFound();
            }
            else 
            {
                ProjetoModel = projetomodel;
            }
            return Page();
        }
    }
}

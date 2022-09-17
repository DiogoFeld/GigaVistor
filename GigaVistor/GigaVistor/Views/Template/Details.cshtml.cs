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
    public class DetailsModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public DetailsModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

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
    }
}

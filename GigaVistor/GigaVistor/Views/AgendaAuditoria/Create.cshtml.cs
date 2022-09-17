﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GigaVistor.Data;
using GigaVistor.Models;

namespace GigaVistor.Views.AgendaAuditoria
{
    public class CreateModel : PageModel
    {
        private readonly GigaVistor.Data.GigaVistorContext _context;

        public CreateModel(GigaVistor.Data.GigaVistorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AgendamentoAuditoriaModel AgendamentoAuditoriaModel { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AgendamentosAuditoria.Add(AgendamentoAuditoriaModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

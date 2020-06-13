using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb_Angeles.Data;
using MegaDeskWeb_Angeles.Models;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;

namespace MegaDeskWeb_Angeles.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext _context;

        public CreateModel(MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DeskQuote.DrawerCost = DeskQuote.calcDrawerCost();
            DeskQuote.MaterialCost = DeskQuote.calcMaterialCost();
            DeskQuote.SurfaceAreaCost = DeskQuote.calcSurfaceAreaCost();
            DeskQuote.RushCost = DeskQuote.calcRushOrderCost();
            DeskQuote.QuoteTotal = DeskQuote.calcQuoteTotal();

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

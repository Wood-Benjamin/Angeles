using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaDeskWeb_Angeles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaDeskWeb_Angeles.Pages.Quotes
{
    public class ViewQuoteModel : PageModel
    {
        private readonly MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext _context;

        public ViewQuoteModel(MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext context)
        {
            _context = context;
        }

       
        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
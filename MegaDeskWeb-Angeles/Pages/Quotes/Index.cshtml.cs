using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_Angeles.Data;
using MegaDeskWeb_Angeles.Models;

namespace MegaDeskWeb_Angeles.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext _context;

        public IndexModel(MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {


            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<DeskQuote> quotes = from s in _context.DeskQuote
                                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    quotes = quotes.OrderBy(s => s.CustomerName);
                    break;
            }

           // var quotes = from m in _context.DeskQuote
           //              select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            DeskQuote = await quotes.AsNoTracking().ToListAsync();
            DeskQuote = await quotes.ToListAsync();
        }

    }
}

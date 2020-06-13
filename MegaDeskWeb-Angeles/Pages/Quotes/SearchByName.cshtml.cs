using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaDeskWeb_Angeles.Pages.Quotes
{
    public class SearchByNameModel : PageModel
    {
       
       
            private readonly MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext _context;

            public SearchByNameModel(MegaDeskWeb_Angeles.Data.MegaDeskWeb_AngelesContext context)
            {
                _context = context;
            }

           
            [BindProperty(SupportsGet = true)]
            public string SearchString { get; set; }
      //  public int Id { get;set }

          //  public void onGet()
            //{
              //  var quotes = from m in _context.DeskQuote
                //             select m;
                //if (!string.IsNullOrEmpty(SearchString))
               // {
                 //   quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
                //}
                
              //  DeskQuote = await quotes.ToListAsync();
           // return RedirectToPage("./Index");
        //}

        //}
    //}

}
}
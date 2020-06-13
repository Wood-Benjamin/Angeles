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

       public decimal calcDrawerCost() => DeskQuote.Drawers * 50;

        public decimal calcMaterialCost()
        {
            switch (DeskQuote.Material)

            {

                case "Laminate":

                    return 100;

                case "Oak":

                    return 200;

                case "Pine":

                    return 50;

                case "Rosewood":

                    return 300;

                case "Veneer":

                    return 125;

                default:

                    return 0;

            }
        }
        public decimal calcSurfaceAreaCost()
        {

            if (DeskQuote.SurfaceArea > 1000)

            { 
                return (DeskQuote.SurfaceArea - 1000) * 1;
            }else
                {
                return 0;
            }
        }
        public decimal calcRushOrderCost()

        {

            //DeskQuote.rushOrderPrices = DeskQuote.GetRushOrderPrices();

            if (DeskQuote.Rush == 14)

            {

                return 0;

            }

            else if (DeskQuote.Rush == 3)

            {

                if (DeskQuote.SurfaceArea < 1000)

                {

                    return 60;

                }

                else if (DeskQuote.SurfaceArea >= 1000 && DeskQuote.SurfaceArea <= 2000)

                {

                    return 70;

                }

                else

                {

                    return 80;

                }

            }

            else if (DeskQuote.Rush == 5)

            {

                if (DeskQuote.SurfaceArea < 1000)

                {

                    return 40;

                }

                else if (DeskQuote.SurfaceArea >= 1000 && DeskQuote.SurfaceArea <= 2000)

                {

                    return 50;

                }

                else

                {

                    return 60;

                }

            }

            else if (DeskQuote.Rush == 7)

            {

                if (DeskQuote.SurfaceArea < 1000)

                {

                    return 30;

                }

                else if (DeskQuote.SurfaceArea >= 1000 && DeskQuote.SurfaceArea <= 2000)

                {

                    return 35;

                }

                else

                {

                    return 40;

                }

            }

            else

            {

                return 1;

            }

        }
        public decimal calcQuoteTotal()
        {
            return DeskQuote.DrawerCost + DeskQuote.MaterialCost + DeskQuote.SurfaceAreaCost + DeskQuote.RushCost;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        protected void Page_Load(object sender, EventArgs e)
        {
           
    
                DeskQuote.QuoteDate = DateTime.Today;
                
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            DeskQuote.DrawerCost = calcDrawerCost();
            DeskQuote.MaterialCost = calcMaterialCost();
            DeskQuote.SurfaceAreaCost = calcSurfaceAreaCost();
            DeskQuote.RushCost = calcRushOrderCost();
            DeskQuote.QuoteTotal = calcQuoteTotal();

            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

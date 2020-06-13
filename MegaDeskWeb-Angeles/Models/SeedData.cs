using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDeskWeb_Angeles.Data;

namespace MegaDeskWeb_Angeles.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWeb_AngelesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskWeb_AngelesContext>>()))
            {
                // Look for any movies.
                if (context.DeskQuote.Any())
                {
                    return;   // DB has been seeded
                }

                context.DeskQuote.AddRange(
                    new DeskQuote
                    {
                        CustomerName = "Ben Wood",
                        QuoteDate = DateTime.Parse("2019-10-8"),
                        Width = 45,
                        Depth = 45,
                        Drawers = 0,
                        Material = "Rosewood",
                        Rush = 0,
                        MaterialCost = 300.00M,
                        SurfaceAreaCost = 1025.00M,
                        DrawerCost = 0.00M,
                        RushCost = 0.00M,
                        QuoteTotal = 1525.00M
                    },

                    new DeskQuote
                    {
                        CustomerName = "Christina Wright",
                        QuoteDate = DateTime.Parse("2020-06-12"),
                        Width = 40,
                        Depth = 45,
                        Drawers = 0,
                        Material = "Oak",
                        Rush = 5,
                        MaterialCost = 200.00M,
                        SurfaceAreaCost = 1025.00M,
                        DrawerCost = 0.00M,
                        RushCost = 50.00M,
                        QuoteTotal = 1250.00M
                    },

                    new DeskQuote
                    {
                        CustomerName = "Mason Wood",
                        QuoteDate = DateTime.Parse("2020-06-12"),
                        Width = 45,
                        Depth = 30,
                        Drawers = 5,
                        Material = "Laminate",
                        Rush = 7,
                        MaterialCost = 100.00M,
                        SurfaceAreaCost = 350.00M,
                        DrawerCost = 250.00M,
                        RushCost = 35.00M,
                        QuoteTotal = 935.00M
                    },

                    new DeskQuote
                    {
                        CustomerName = "Bryan Cook",
                        QuoteDate = DateTime.Parse("2020-06-12"),
                        Width = 45,
                        Depth = 45,
                        Drawers = 2,
                        Material = "Pine",
                        Rush = 3,
                        MaterialCost = 50.00M,
                        SurfaceAreaCost = 1025.00M,
                        DrawerCost = 100.00M,
                        RushCost = 80.00M,
                        QuoteTotal = 1455.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

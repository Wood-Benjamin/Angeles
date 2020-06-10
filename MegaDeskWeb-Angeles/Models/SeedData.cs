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
                        CustomerName = "Sarah Reed",
                        QuoteDate = DateTime.Parse("2020-2-12"),
                        Width = 25,
                        Depth = 25,
                        Drawers = 2,
                        Material = "Oak",
                        Rush = 14,
                        MaterialCost = 200,
                        SurfaceAreaCost = 0,
                        DrawerCost = 100,
                        RushCost = 0,
                        QuoteTotal = 925

                    },

                    new DeskQuote
                    {
                        CustomerName = "Traesa Titel",
                        QuoteDate = DateTime.Parse("2020-2-12"),
                        Width = 25,
                        Depth = 25,
                        Drawers = 2,
                        Material = "Pine",
                        Rush = 14,
                        MaterialCost = 50,
                        SurfaceAreaCost = 0,
                        DrawerCost = 100,
                        RushCost = 0,
                        QuoteTotal = 775

                    }
                );
                context.SaveChanges();
            }
        }
    }
}

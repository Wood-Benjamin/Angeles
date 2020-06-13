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
                        Material = "Pine",
                        Rush = 0,
                        MaterialCost = 50.00M,
                        SurfaceAreaCost = 200.00M,
                        DrawerCost = 0.00M,
                        RushCost = 0.00M,
                        QuoteTotal = 34.00M
                    },

                    new DeskQuote
                    {
                        CustomerName = "Mason Wood",
                        QuoteDate = DateTime.Parse("2020-06-12"),
                        Width = 45,
                        Depth = 45,
                        Drawers = 0,
                        Material = "Oak",
                        Rush = 0,
                        MaterialCost = 50.00M,
                        SurfaceAreaCost = 200.00M,
                        DrawerCost = 0.00M,
                        RushCost = 0.00M,
                        QuoteTotal = 34
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

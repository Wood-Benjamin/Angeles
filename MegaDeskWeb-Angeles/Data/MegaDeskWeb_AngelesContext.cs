using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_Angeles.Models;

namespace MegaDeskWeb_Angeles.Data
{
    public class MegaDeskWeb_AngelesContext : DbContext
    {
        public MegaDeskWeb_AngelesContext (DbContextOptions<MegaDeskWeb_AngelesContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb_Angeles.Models.DeskQuote> DeskQuote { get; set; }
    }
}

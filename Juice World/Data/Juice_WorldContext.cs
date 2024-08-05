using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Juice_World.Models;

namespace Juice_World.Data
{
    public class Juice_WorldContext : DbContext
    {
        public Juice_WorldContext (DbContextOptions<Juice_WorldContext> options)
            : base(options)
        {
        }

        public DbSet<Juice_World.Models.Juice> Juice { get; set; } = default!;
    }
}

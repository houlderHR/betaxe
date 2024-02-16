using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using client.Models;

namespace client.Data
{
    public class BetaxeContext : DbContext
    {
        public BetaxeContext (DbContextOptions<BetaxeContext> options)
            : base(options)
        {
        }

        public DbSet<client.Models.Versement> Versement { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Versement>()
                .HasMany(e => e.Events)
                .WithOne()
                .HasForeignKey("VersementId")
                .IsRequired(false);
        }
        public DbSet<client.Models.Event> Event { get; set; } = default!;
    }
}

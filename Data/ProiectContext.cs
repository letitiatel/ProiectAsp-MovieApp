using Microsoft.EntityFrameworkCore;
using Proiectasp.Models;
using System.Collections.Generic;

namespace Proiectasp.Data
{
    public class ProiectContext : DbContext
    {
        // One to Many
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Producer>()
                       .HasMany(m1 => m1.Movies)
                       .WithOne(m2 => m2.Producer);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}

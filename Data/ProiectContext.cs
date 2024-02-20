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

        
        public DbSet<Role> Roles { get; set; }

        public DbSet<ProducerDetails> ProducerDetailss { get; set; }


        // Many to Many

        // public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ModelsRelation> ModelsRelations { get; set; }

        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // One to many
            modelBuilder.Entity<Producer>()
                       .HasMany(m1 => m1.Movies)
                       .WithOne(m2 => m2.Producer);

            // Many to Many
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.MovieId, mr.UserId });

            //One to many
            modelBuilder.Entity<Role>()
                      .HasMany(m1 => m1.Users)
                      .WithOne(m2 => m2.Role);

            //One to one
            modelBuilder.Entity<Producer>()
                .HasOne(m5 => m5.ProducerDetails)
                .WithOne(m6 => m6.Producer)
                .HasForeignKey<ProducerDetails>(m6 => m6.ProducerId);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}

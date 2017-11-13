using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetPizza.Models;

namespace DotNetPizza.Data
{
    public class DotNetPizzaDbContext : DbContext
    {
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Command> Command { get; set; }
        public virtual DbSet<DetailCommand> DetailCommand { get; set; }

        public DotNetPizzaDbContext(DbContextOptions<DotNetPizzaDbContext> options)
            : base(options)
        {

        }

        public DotNetPizzaDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DotNetPizza_Cours;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.Description).IsRequired();

                entity.HasMany(e => e.DetailCommand)
                    .WithOne(e => e.Pizza)
                    .HasForeignKey(e => e.PizzaID)
                    .IsRequired();
                    
            });

            modelBuilder.Entity<Command>(entity =>
            {
                entity.Property(c => c.CommandDate).IsRequired();

                entity.HasMany(e => e.DetailCommand)
                .WithOne(e => e.Command)
                .HasForeignKey(e => e.CommandID)
                .IsRequired();
                
            });

        }
    }
}

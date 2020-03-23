using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Data.Mappers;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Opmerking> Opmerkingen { get; set; }

        //Niet zeker wat dit doet
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = @"Server=.;Database=Quotes;Integrated Security=True;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AuteurConfiguration());
            builder.ApplyConfiguration(new OpmerkingConfiguration());
            builder.ApplyConfiguration(new QuoteConfiguration());
        }
    }
}

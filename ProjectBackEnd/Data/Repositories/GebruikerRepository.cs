using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }

        public Gebruiker GetBy(string gebruikersnaam)
        {
            return _gebruikers.Where(c => c.Gebruikesnaam == gebruikersnaam).SingleOrDefault();
        }

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

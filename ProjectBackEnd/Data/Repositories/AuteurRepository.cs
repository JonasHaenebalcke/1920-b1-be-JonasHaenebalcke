using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBackEnd.Data.Repositories
{
    public class AuteurRepository : IAuteurRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Auteur> _auteurs;

        public AuteurRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _auteurs = dbContext.Auteurs;
        }

        public void Add(Auteur auteur)
        {
            _auteurs.Add(auteur);
        }

        public IEnumerable<Auteur> GetAll()
        {
            return _auteurs.Include(a => a.Quotes).ToList().OrderBy(a => a.Achternaam);
        }

        public Auteur GetBy(int id)
        {
            return _auteurs.Where(a => a.Id == id).Include(a => a.Quotes).FirstOrDefault();
        }

        public Auteur getByName(string name)
        {
            return _auteurs.Where(a => (a.Voornaam + " " + a.Achternaam).ToLower().Equals(name)).Include(a => a.Quotes).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

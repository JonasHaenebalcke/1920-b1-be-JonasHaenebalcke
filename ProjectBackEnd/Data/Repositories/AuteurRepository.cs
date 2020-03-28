using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<Auteur> GetAll()
        {
            return _auteurs.Include(a => a.Quotes).ToList().OrderBy(a => a.Achternaam);
        }

        public Auteur GetBy(int id)
        {
            return _auteurs.Where(a => a.Id == id).Include(a => a.Quotes).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

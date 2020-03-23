using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data
{
    public class ApplicationDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();

            if (_context.Database.EnsureCreated())
            {
                //Auteurs
                Auteur axel = new Auteur("Axel", "Beuselinck", new DateTime(2001, 2, 19), null, "Axel beuselinck is een heel speciaal individu, hij heeft nooit zijn studies afgemaakt, maar produceert gelukkig wel veel amusante quotes", null);
                _context.SaveChanges();

                //Quotes
                Quote quote1 = new Quote("Omg, that's like the Netherlands and Dutch language combined!", new DateTime(2019, 1, 25), axel);
                _context.SaveChanges();
            }
        }
    }
}

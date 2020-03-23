using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Quote> _quotes;

        public QuoteRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _quotes = dbContext.Quotes;
        }


        public IEnumerable<Quote> GetAll()
        {
            return _quotes.Include(q => q.Opmerkingen).Include(q => q.Auteur).ToList();
        }

        public IEnumerable<Quote> GetAllOrderByDate()
        {
            return _quotes.OrderBy(q => q.Date).ToList();
        }

        public Quote GetBy(int id)
        {
            return _quotes.Where(q => q.Id == id).FirstOrDefault();
        }

        public IEnumerable<Quote> GetByAuteur(int id)
        {
            return _quotes.Where(q => q.Auteur.Id == id).ToList();
        }

        public IEnumerable<Quote> GetAllOrderByRating()
        {
            return _quotes.OrderBy(q => q.Rating).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

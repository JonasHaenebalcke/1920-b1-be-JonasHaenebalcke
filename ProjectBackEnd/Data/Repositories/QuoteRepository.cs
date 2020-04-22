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
            return _quotes.Include(q => q.Opmerkingen).Include(q => q.Auteur).OrderBy(q => q.Date).ToList();
        }

        //public IEnumerable<Quote> GetAllOrderByDate()
        //{
        //    return _quotes.OrderBy(q => q.Date).Include(q => q.Opmerkingen).Include(q => q.Auteur).ToList();
        //}

        public Quote GetBy(int id)
        {
            return _quotes.Where(q => q.Id == id).Include(q => q.Opmerkingen).Include(q => q.Auteur).FirstOrDefault();
        }

        public IEnumerable<Quote> GetByAuteur(int id)
        {
            return _quotes.Where(q => q.Auteur.Id == id).Include(q => q.Opmerkingen).Include(q => q.Auteur).ToList();
        }

        public IEnumerable<Quote> GetAllOrderByRating()
        {
            return _quotes.OrderBy(q => q.Rating).Include(q => q.Opmerkingen).Include(q => q.Auteur).ToList();
        }

        public void Add(Quote quote)
        {
            _quotes.Add(quote);
        }

        public void Update(Quote quote)
        {
            _context.Update(quote);
        }

        public void Delete(Quote quote)
        {
            _quotes.Remove(quote);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

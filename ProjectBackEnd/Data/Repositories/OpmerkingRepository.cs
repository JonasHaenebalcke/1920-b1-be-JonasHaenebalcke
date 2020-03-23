using Microsoft.EntityFrameworkCore;
using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectBackEnd.Data.Repositories
{
    public class OpmerkingRepository : IOpmerkingRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Opmerking> _opmerkingen;

        public OpmerkingRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _opmerkingen = dbContext.Opmerkingen;
        }


        public IEnumerable<Opmerking> GetAll(int quoteId)
        {
            return _opmerkingen.Where(o => o.Quote.Id == quoteId).Include(o => o.Quote).ToList();
        }

        public Opmerking GetBy(int id)
        {
            return _opmerkingen.Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<Opmerking> GetAllOrderByRating(int quoteId)
        {
            return _opmerkingen.Where(o => o.Quote.Id == quoteId).OrderBy(o => o.Rating).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

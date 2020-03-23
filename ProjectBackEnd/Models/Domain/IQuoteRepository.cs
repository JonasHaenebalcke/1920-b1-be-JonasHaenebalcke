using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public interface IQuoteRepository
    {
        Quote GetBy(int id);
        IEnumerable<Quote> GetAll();
        IEnumerable<Quote> GetByAuteur(int id);
        IEnumerable<Quote> GetAllOrderByDate();
        IEnumerable<Quote> GetAllOrderByRating();
        void SaveChanges();
    }
}

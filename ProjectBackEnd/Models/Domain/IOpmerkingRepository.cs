using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public interface IOpmerkingRepository
    {
        Opmerking GetBy(int id);
        IEnumerable<Opmerking> GetAll(int quoteId);
        IEnumerable<Opmerking> GetAllOrderByRating(int quoteId);
        void SaveChanges();
    }
}

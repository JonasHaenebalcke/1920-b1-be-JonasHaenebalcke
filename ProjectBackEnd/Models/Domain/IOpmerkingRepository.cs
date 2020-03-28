using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public interface IOpmerkingRepository
    {
        Opmerking GetBy(int id);
        IEnumerable<Opmerking> GetAllOrderByDate(int quoteId);
        void SaveChanges();
    }
}

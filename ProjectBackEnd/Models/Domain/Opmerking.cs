using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public class Opmerking
    {
        #region Properties
        public string Inhoud { get; set; }
        public DateTime Date { get; set; }
        public Quote Quote { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
        #endregion

        #region Constructor
        public Opmerking(string inhoud, DateTime date, Quote quote, int rating)
        {
            Inhoud = inhoud;
            Date = date;
            Quote = quote;
            Rating = rating;
        }

        public Opmerking()
        {

        }
        #endregion

    }
}

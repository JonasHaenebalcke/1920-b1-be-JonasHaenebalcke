using System;

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
        public string Auteur { get; set; }
        #endregion

        #region Constructor 
        public Opmerking(string inhoud, DateTime date, Quote quote, string auteur)
        {
            Inhoud = inhoud;
            Date = date;
            Quote = quote;
            Rating = 0;
            Auteur = auteur;
        }

        public Opmerking() { }
        #endregion

    }
}

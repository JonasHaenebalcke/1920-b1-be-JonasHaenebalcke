using System;
using System.Collections.Generic;

namespace ProjectBackEnd.Models
{
    public class Auteur
    {
        #region Properties
        public String Voornaam { get; set; }
        public string Achternaam { get; set; }
        public ICollection<Quote> Quotes { get; set; }
        //public DateTime GeboortDatum { get; set; }
        public string Omschrijving { get; set; }
        public string? Foto { get; set; }

        public int Id { get; set; }
        #endregion

        #region Constructor
        public Auteur(string voornaam, string achternaam, /*DateTime geboortDatum,*/ string omschrijving, string? foto)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            /*GeboortDatum = geboortDatum;*/
            Omschrijving = omschrijving;
            Foto = foto;
        }

        public Auteur()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Voegt een quote toe met de gewenste auteur
        /// </summary>
        /// <param name="quote"></param>
        public void AddQuote(Quote quote)
        {
            Quotes.Add(quote);
        }
        #endregion
    }
}

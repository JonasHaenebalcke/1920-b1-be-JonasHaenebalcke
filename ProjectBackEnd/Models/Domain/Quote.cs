using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public class Quote
    {
        #region Properties
        public string Inhoud { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Opmerking> Opmerkingen { get; set; }
        public Auteur Auteur { get; set; }
        public int Id { get; set; }
        #endregion

        #region Constructor
        public Quote(string inhoud, DateTime date, Auteur auteur)
        {
            Inhoud = inhoud;
            Rating = 0;
            Date = date;
            Auteur = auteur;
        }

        public Quote()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Voegt een opemerking toen aan de gewenste quote
        /// </summary>
        /// <param name="opmerking"></param>
        public void AddOpmerking(Opmerking opmerking)
        {
            Opmerkingen.Add(opmerking);
        }
        #endregion


    }
}

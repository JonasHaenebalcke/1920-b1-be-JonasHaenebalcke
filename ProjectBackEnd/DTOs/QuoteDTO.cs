using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.DTOs
{
    public class QuoteDTO
    {
        public string Inhoud { get; set; }
        public DateTime Date { get; set; }
        public int auteurId { get; set; }
        //public Auteur Auteur { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.DTOs
{
    public class AuteurDTO
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime GeboortDatum { get; set; }
        public DateTime? SterfDatum { get; set; }
        public string Omschrijving { get; set; }

        //Hoe zou ik dit meegeven?
        //public string? Foto { get; set; }
    }
}

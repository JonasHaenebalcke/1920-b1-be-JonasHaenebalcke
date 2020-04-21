using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.DTOs
{
    public class AuteurDTO
    {
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        //public DateTime GeboortDatum { get; set; }
        public string Omschrijving { get; set; }

        //Hoe zou ik dit meegeven?
        //public string? Foto { get; set; }
    }
}

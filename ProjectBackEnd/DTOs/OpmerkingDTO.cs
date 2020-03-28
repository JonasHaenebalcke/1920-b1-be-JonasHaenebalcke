using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.DTOs
{
    public class OpmerkingDTO
    {
        //Quote en Auteur nodig? Nog niet zeker hoe DTO werkt
        public string Inhoud { get; set; }
        public DateTime Date { get; set; }
        public Quote Quote { get; set; }
        public int Rating { get; set; }
        public Auteur Auteur { get; set; }
    }
}

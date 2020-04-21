using ProjectBackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.DTOs
{
    public class OpmerkingDTO
    {
        //Quote en Auteur nodig? Nog niet zeker hoe DTO werkt
        [Required]
        public string Inhoud { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //[Required]
        //public Quote Quote { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Auteur { get; set; }
    }
}

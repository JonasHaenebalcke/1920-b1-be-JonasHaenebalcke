using System.ComponentModel.DataAnnotations;

namespace ProjectBackEnd.DTOs
{
    public class LoginDTO
    {
        
        [EmailAddress] 
        public string Gebruikersnaam { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
    }
}

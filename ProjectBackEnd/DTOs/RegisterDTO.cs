﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectBackEnd.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(200)]
        public String Voornaam { get; set; }

        [Required]
        [StringLength(250)]
        public String Achternaam { get; set; }


        [Required]
        [Compare("Wachtwoord")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [StringLength(50, MinimumLength =6)]    
        public String BevestigWachtwoord { get; set; }
    }
}

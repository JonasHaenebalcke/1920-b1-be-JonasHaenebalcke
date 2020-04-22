namespace ProjectBackEnd.Models.Domain
{
    public class Gebruiker
    {
        #region Propertiers
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikesnaam { get; set; }
        public string Rol { get; set; }
        #endregion

        #region Constructors
        public Gebruiker()
        {

        }

        public Gebruiker(string voornaam, string achternaam, string gebruikersnaam, string rol)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Gebruikesnaam = gebruikersnaam;
            Rol = rol;
        }
        #endregion
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models.Domain
{
    public interface IGebruikerRepository
    {
        Gebruiker GetBy(string gebruikersnaam);
        void Add(Gebruiker gebruiker);
        void SaveChanges();
    }
}

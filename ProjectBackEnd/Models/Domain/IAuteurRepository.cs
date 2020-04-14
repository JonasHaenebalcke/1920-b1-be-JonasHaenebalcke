using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBackEnd.Models
{
    public interface IAuteurRepository
    {
        Auteur GetBy(int id);
        IEnumerable<Auteur> GetAll();
        void SaveChanges();
        Auteur GetByName(string name);
        void Add(Auteur auteur);
    }
}

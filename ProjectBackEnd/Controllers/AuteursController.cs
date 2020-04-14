using Microsoft.AspNetCore.Mvc;
using ProjectBackEnd.DTOs;
using ProjectBackEnd.Models;
using System.Collections.Generic;

namespace ProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteursController : ControllerBase
    {
        private readonly IAuteurRepository _auteurRepository;

        public AuteursController(IAuteurRepository auteur)
        {
            _auteurRepository = auteur;
        }

        /// <summary>
        /// Geeft alle auteurs terug
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Auteur> GetAuteurs()
        {
            return _auteurRepository.GetAll();
        }

        [HttpGet("{naam}")]
        public ActionResult<Auteur> GetAuteurByName(string naam)
        {
            /*  Quote quote = _quoteRepository.GetBy(id);
             if (quote == null)
                 return NotFound();
             return quote;*/

            Auteur auteur = _auteurRepository.GetByName(naam);
            if (auteur == null)
                return NotFound();
            return auteur;
        }


        /// <summary>
        /// Maakt een nieuwe auteur aan
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostAuteur(AuteurDTO dto)
        {
            Auteur auteur = new Auteur(dto.Voornaam, dto.Achternaam, dto.GeboortDatum, dto.Omschrijving, null);
            _auteurRepository.Add(auteur);
            _auteurRepository.SaveChanges();
            return CreatedAtAction(nameof(GetAuteurByName), new { naam = auteur.Voornaam + " " + auteur.Achternaam }, auteur);

        }
    }
}
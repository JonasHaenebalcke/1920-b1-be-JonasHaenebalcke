using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBackEnd.Models;

namespace ProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteursController : ControllerBase
    {
        private readonly IAuteurRepository _auteurRepository;
        private readonly IOpmerkingRepository _opmerkingRepository;
        private readonly IQuoteRepository _quoteRepository;

        public AuteursController(IAuteurRepository auteur, IOpmerkingRepository opmerking, IQuoteRepository quote)
        {
            _auteurRepository = auteur;
            _opmerkingRepository = opmerking;
            _quoteRepository = quote;
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
    }
}
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
    }
}
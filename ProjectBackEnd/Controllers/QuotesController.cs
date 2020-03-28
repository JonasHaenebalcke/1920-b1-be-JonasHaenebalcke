﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBackEnd.DTOs;
using ProjectBackEnd.Models;

namespace ProjectBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {   
        private readonly IOpmerkingRepository _opmerkingRepository;
        private readonly IQuoteRepository _quoteRepository;

        public QuotesController(IOpmerkingRepository opmerking, IQuoteRepository quote)
        {
            _opmerkingRepository = opmerking;
            _quoteRepository = quote;
        }
        // GET: api/Quotes
        /// <summary>
        /// Geeft alle quotes terug, gestorteerd op datum
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Quote> GetQuotes()
        {
            return _quoteRepository.GetAll();
        }

        /// <summary>
        /// Geeft quote van gegeven id terug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuote(int id)
        {
            Quote quote = _quoteRepository.GetBy(id);
            if (quote == null)
                return NotFound();
            return quote;
        }

        /// <summary>
        /// Maakt een nieuwe quote
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostQuote(QuoteDTO dto)
        {
            Quote quote = new Quote(dto.Inhoud, dto.Date, dto.Auteur);
            _quoteRepository.Add(quote);
            _quoteRepository.SaveChanges();
            return CreatedAtAction(nameof(GetQuote), new { id = quote.Id }, quote);

        }

        /// <summary>
        /// Update een quote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutQuote(int id, Quote quote)
        {
            if (id != quote.Id)
                return BadRequest();

            _quoteRepository.Update(quote);
            _quoteRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Verwijderd een quote
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            Quote quote = _quoteRepository.GetBy(id);
            if(quote == null)            
                return NotFound();

            _quoteRepository.Delete(quote);
            _quoteRepository.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Geeft alle opmerkingen van een meegegeven quote, geordend op datum
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/opmerkingen")]
        public IEnumerable<Opmerking>GetOpmerkingenByDate(int id)//id is quote id
        {
           return _opmerkingRepository.GetAllOrderByDate(id);
        }

        /// <summary>
        /// Plaatst een opmerking bij de meegegeven quote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("{id}/opmerkingen")]
        public ActionResult<Opmerking> PostOpmerking(int id, OpmerkingDTO dto)
        {
            Quote quote = _quoteRepository.GetBy(id);
            if(quote == null)
            {
                return NotFound();
            }
            quote.AddOpmerking(new Opmerking(dto.Inhoud, dto.Date, dto.Quote, dto.Auteur));
            _quoteRepository.SaveChanges();
            return CreatedAtAction(nameof(GetOpmerkingenByDate), new { id = quote.Id }, quote);
        }
    }
}
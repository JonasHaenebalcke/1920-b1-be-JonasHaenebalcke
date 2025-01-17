﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectBackEnd.DTOs;
using ProjectBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IGebruikerRepository gebruikerRepository, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _gebruikerRepository = gebruikerRepository;
            _config = config;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="model"> details van gebruiker</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {

            IdentityUser user = new IdentityUser { UserName = model.Gebruikersnaam };
            Gebruiker gebruiker = new Gebruiker(model.Voornaam, model.Achternaam, model.Gebruikersnaam, "gebruiker");
            var result = await _userManager.CreateAsync(user, model.Wachtwoord);

            if (result.Succeeded)
            {
                _gebruikerRepository.Add(gebruiker);
                _gebruikerRepository.SaveChanges();
                string token = await GetTokenAsync(user);
                return Created("", token);
            }
            return BadRequest();
        }

        /// <summary>
        /// controleert of een gebruikersnaam nog beschikbaar is
        /// </summary>
        /// <param name="gebuikersnaam"></param>
        /// <returns>of gebruikersnaam nog beschrikbaar is</returns>
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>>
        CheckAvailableUserName(string gebuikersnaam)
        {
            var user = await _userManager.FindByNameAsync(gebuikersnaam);
            return user == null;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">gegevens van gebruiker</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Gebruikersnaam); if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Wachtwoord, false); if (result.Succeeded)
                {
                    string token = await GetTokenAsync(user); return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Maakt een token aan voor een nieuwe gebruiker
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Een string van de token</returns>
        private async Task<string> GetTokenAsync(IdentityUser user)
        {
            var RoleClaims = await _userManager.GetClaimsAsync(user);
            // Createthetoken
            var claims = new List<Claim>() {
              //  new Claim(JwtRegisteredClaimNames.Sub, user.Email), Niet zeker of dit in commentaar mag
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            claims.AddRange(RoleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}



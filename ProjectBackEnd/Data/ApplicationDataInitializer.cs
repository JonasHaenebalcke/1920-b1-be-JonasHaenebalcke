using Microsoft.AspNetCore.Identity;
using ProjectBackEnd.Models;
using ProjectBackEnd.Models.Domain;
using System;
using System.Threading.Tasks;

namespace ProjectBackEnd.Data
{
    public class ApplicationDataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ApplicationDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();

            if (_context.Database.EnsureCreated())
            {
                //Auteurs
                Auteur axel = new Auteur("Axel", "Beuselinck", /*new DateTime(2001, 2, 19),*/ "Een feestbeest dat heel gemotiveerd is om te werken, maar niet voor school. Dit zorgt natuurlijk voor een individu dat heel plezante dingen kan zeggen.", null);
                Auteur jonas = new Auteur("Jonas", "Haenebalcke", /*new DateTime(2000, 8, 10),*/ "Een ijverige student die af en toe wel iets grappigs zegt.", null);
                Auteur wout = new Auteur("Wout", "Van Kets", /*new DateTime(2000, 7, 11),*/ "Een lieve jongen, maar met heel flauwe humor.", null);
                _context.Auteurs.AddRange(axel, jonas, wout);
                _context.SaveChanges();

                //Quotes
                Quote quote1 = new Quote("Omg, that's like the Netherlands and Dutch language combined!", new DateTime(2019, 1, 25), axel);
                Quote quote2 = new Quote("Ik ben uw animal king", new DateTime(2019, 1, 11), jonas) { Rating = 5 };
                Quote quote3 = new Quote("Do you even intellect?", new DateTime(2019, 1, 25), wout);
                Quote quote4 = new Quote("How many IQ cells do you have?", new DateTime(2019, 2, 19), axel);
                Quote quote5 = new Quote("Ik trigger weinig mensen", new DateTime(2019, 9, 10), axel);
                _context.Quotes.AddRange(quote1, quote2, quote3, quote4, quote5);
                _context.SaveChanges();

                Opmerking opmerking1 = new Opmerking("Nice one Axel", new DateTime(2020, 3, 20, 12, 30, 0), quote1, "Random Gebruiker");
                Opmerking opmerking2 = new Opmerking("Nice one Jonas", new DateTime(2020, 3, 15, 15, 40, 0), quote2, "Random Gebruiker");
                Opmerking opmerking3 = new Opmerking("Nice one Wout", new DateTime(2020, 3, 10, 18, 20, 0), quote3, "Random Gebruiker");
                Opmerking opmerking4 = new Opmerking("Haha", new DateTime(2020, 3, 10, 14, 10, 00), quote2, "Random Gebruiker");
                Opmerking opmerking5 = new Opmerking("That's the spirit", new DateTime(2020, 3, 5, 20, 20, 20), quote2, "Random Gebruiker");

                _context.Opmerkingen.AddRange(opmerking1, opmerking2, opmerking3, opmerking4, opmerking5);
                _context.SaveChanges();



                Gebruiker gebruiker = new Gebruiker("Jonas", "Haenebalcke", "Jonidinges");
                _context.Gebruikers.Add(gebruiker);
                await CreateUser(gebruiker.Gebruikesnaam, "wachtwoord");
                _context.SaveChanges();
            }
        }


        private async Task CreateUser(string gebruikersnaam, string password)
        {
            var user = new IdentityUser { UserName = gebruikersnaam };
            await _userManager.CreateAsync(user, password);
        }
    }
}

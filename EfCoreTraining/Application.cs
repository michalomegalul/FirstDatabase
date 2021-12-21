using EfCoreTraining.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreTraining
{
    public class Application
    {
        private readonly DatabaseContext _context;
        private const string ADMIN_NAME = "Jááá";

        public Application()
        {
            _context = new DatabaseContext();
        }

        public void Run()
        {
            SeedAdmin();

            foreach (var user in _context.Users)
            {
                Console.WriteLine($"{user.Name} ({user.Id})");
                foreach (var acc in user.BankAccounts)
                {
                    Console.WriteLine($"{acc.Name} ({acc.Number}): {acc.Balance} Kč");
                }
            }
        }

        private void SeedAdmin()
        {
            var user = _context.Users.SingleOrDefault(u => u.Name == ADMIN_NAME);

            var accounts = new List<BankAccount>
            {
                new BankAccount
                {
                    Name = "Hlavní",
                    Number = "123123123",
                    Balance = 15230.25m,
                },
                new BankAccount
                {
                    Name = "Dovolená",
                    Number = "987987987",
                    Balance = 1.50m,
                },
            };

            if (user is null)
            {
                user = new User
                {
                    Name = ADMIN_NAME,
                };
                _context.Add(user);
            }
            else
            {
                if (user.BankAccounts.Count == 0)
                {
                    foreach (var acc in accounts)
                    {
                        user.BankAccounts.Add(acc);
                    }
                }
                _context.Update(user);
            }

            _context.SaveChanges();
        }
    }
}
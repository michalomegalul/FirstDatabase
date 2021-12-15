using EfCoreTraining.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
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
            if (!_context.Users.Any(x => x.Name == ADMIN_NAME))
            {
                _context.Add(new User
                {
                    Name = ADMIN_NAME,
                });

                _context.SaveChanges();
            }

            foreach (var user in _context.Users)
            {
                Console.WriteLine($"{user.Name} ({user.Id})");
            }
        }
    }
}
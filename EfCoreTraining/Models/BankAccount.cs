using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTraining.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
    }
}

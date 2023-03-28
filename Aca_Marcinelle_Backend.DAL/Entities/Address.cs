using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aca_Marcinelle_Backend.DAL.Entities
{
    public class Address
    {
        public int Id { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Number { get; init; }
        public string? Zipcode { get; init; }
        public IEnumerable<Person> Residents { get; init; }
    }
}

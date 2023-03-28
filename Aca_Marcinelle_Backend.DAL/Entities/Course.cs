using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aca_Marcinelle_Backend.DAL.Entities
{
    public class Course
    {
        public int Id { get; init; }
        public int? DomainId { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public bool IsCollective { get; init; }
        public bool IsPrincipal { get; init; }
    }
}

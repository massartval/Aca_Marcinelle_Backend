using System.ComponentModel.DataAnnotations;

namespace Aca_Marcinelle_Backend.DAL.Entities
{
    public class Person
    {
        [Required]
        public int Id { get; init; }
        public int? CategoryId { get; init; }
        [Required, MinLength(1), MaxLength(50)]
        public string FirstName { get; init; }
        [Required, MinLength(1), MaxLength(50)]
        public string LastName { get; init; }
        [Required]
        public DateTime BirthDate { get; init; }
        [Required, MaxLength(50)]
        public string City { get; init; }
        [Required, MaxLength(50)]
        public string Street { get; init; }
        [Required, MaxLength(10)]
        public string HouseNumber { get; init; }
        [MinLength(4), MaxLength(4)]
        public string? Zipcode { get; init; }
        [Required, MinLength(11), MaxLength(11)]
        public string NISS { get; init; }
        [MinLength(5), MaxLength(50)]
        public string? Email { get; init; }
        [MinLength(9), MaxLength(10)]
        public string? PhoneNumber { get; init; }
    }
}

namespace Aca_Marcinelle_Backend.DAL.Entities
{
    public class Student : Person
    {
        public bool IsActive { get; init; }
        public bool RegistrationOK { get; init; }
    }
}
using Aca_Marcinelle_Backend.DAL.Entities;

namespace Aca_Marcinelle_Backend.DAL.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        public IEnumerable<Course> GetByStudentId(int studentId);
    }
}

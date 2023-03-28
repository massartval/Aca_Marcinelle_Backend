using Aca_Marcinelle_Backend.DAL.Entities;

namespace Aca_Marcinelle_Backend.DAL.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public bool ChangeLevel(int studentId, int courseId, int levelId);
        public bool JoinCourse(int studentId, int courseId);
        public bool JoinGroup(int studentId, int groupId);
        public bool LeaveCourse(int studentId, int courseId);
        public bool LeaveGroup(int studentId, int groupId);
    }
}

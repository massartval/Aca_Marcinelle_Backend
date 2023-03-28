using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Aca_Marcinelle_Backend.DAL.Tools;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Aca_Marcinelle_Backend.DAL.Services
{
    public class CourseRepository : IGenericRepository<Course>, ICourseRepository
    {
        private Connection _connection;
        public CourseRepository(Connection connection)
        {
            _connection = connection;
        }

        public static Course MapCourse(SqlDataReader reader)
        {
            return new Course()
            {
                Id = (int)reader["Id"],
                DomainId = (reader["DomainId"] is DBNull ? null : (int)reader["DomainId"]),
                Name = (string)reader["Name"],
                Description = (reader["Description"] is DBNull ? null : (string)reader["Description"]),
                IsCollective = (bool)reader["IsCollective"],
                IsPrincipal = (bool)reader["IsPrincipal"]
            };
        }

        #region SELECT
        public IEnumerable<Course> GetAll()
        {
            string sql = "SELECT * FROM [Courses]";
            Command command = new Command(sql, false);
            return _connection.ExecuteReader(command, reader => MapCourse(reader));
        }

        public Course? GetById(int id)
        {
            string sql = "SELECT * FROM [Courses] " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => MapCourse(reader)).FirstOrDefault();
        }

        public IEnumerable<Course> GetByStudentId(int studentId)
        {
            string sql = "SELECT * FROM [Courses] " +
                            "INNER JOIN [Courses_Students] ON [Courses_Students].[CourseId] = [Courses].[Id] " +
                            "WHERE [Courses_Students].[StudentId] = @studentId";
            Command command = new Command(sql, false);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteReader(command, reader => MapCourse(reader));
        }            
        #endregion

        public bool Create(Course form)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Course form)
        {
            throw new NotImplementedException();
        }
    }
}

using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Aca_Marcinelle_Backend.DAL.Tools;
using System.Data.SqlClient;

namespace Aca_Marcinelle_Backend.DAL.Services
{
    public class StudentRepository : IGenericRepository<Student>, IStudentRepository
    {
        private Connection _connection;
        public StudentRepository(Connection connection)
        {
            _connection = connection;
        }

        public static Student MapStudent(SqlDataReader reader)
        {
            return new Student()
            {
                Id = (int)reader["Id"],
                CategoryId = (reader["CategoryId"] is DBNull ? null : (int)reader["CategoryId"]),
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                BirthDate = (DateTime)reader["BirthDate"],
                City = (string)reader["City"],
                Street = (string)reader["Street"],
                HouseNumber = (string)reader["HouseNumber"],
                Zipcode = (reader["Zipcode"] is DBNull ? null : (string?)reader["Zipcode"]),
                NISS = (string)reader["NISS"],
                Email = (reader["Email"] is DBNull ? null : (string?)reader["Email"]),
                PhoneNumber = (reader["PhoneNumber"] is DBNull ? null : (string?)reader["PhoneNumber"]),
                IsActive = (bool)reader["IsActive"],
                RegistrationOK = (bool)reader["RegistrationOK"]
            };
        }

        #region SELECT
        public IEnumerable<Student> GetAll()
        {
            string sql = "SELECT * FROM [Persons] " +
                            "INNER JOIN [Students] ON [Persons].[Id] = [Students].[Id]";
            Command command = new Command(sql, false);
            return _connection.ExecuteReader(command, reader => MapStudent(reader));
        }

        public Student? GetById(int id)
        {
            string sql = "SELECT * FROM [Persons] " +
                            "INNER JOIN [Students] ON [Persons].[Id] = [Students].[Id] " +
                            "WHERE [Persons].[Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => MapStudent(reader)).FirstOrDefault();
        }
        #endregion

        #region INSERT
        public bool Create(Student form)
        {
            string sql = "INSERT INTO [Students]([Id], [IsActive], [RegistrationOK]) " +
                            "VALUES(@id, @isActive, @registrationOK)";
            Command command = new Command(sql, false);
            command.AddParameter("id", form.Id);
            command.AddParameter("isActive", form.IsActive);
            command.AddParameter("registrationOK", form.RegistrationOK);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool JoinCourse(int studentId, int courseId)
        {
            string sql = "INSERT INTO [Courses_Students]([CourseId], [StudentId]) " +
                            "VALUES(@courseId, @studentId)";
            Command command = new Command(sql, false);
            command.AddParameter("courseId", courseId);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool JoinGroup(int studentId, int groupId)
        {
            string sql = "INSERT INTO [Groups_Students]([GroupId], [StudentId]) " +
                                       "VALUES(@groupId, @studentId)";
            Command command = new Command(sql, false);
            command.AddParameter("groupId", groupId);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion

        #region UPDATE
        public bool Update(Student form)
        {
            string sql = "UPDATE [Students] " +
                            "SET [IsActive] =  @isActive, [RegistrationOK] = @registrationOK " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", form.Id);
            command.AddParameter("isActive", form.IsActive);
            command.AddParameter("registrationOK", form.RegistrationOK);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool ChangeLevel(int studentId, int courseId, int levelId)
        {
            string sql = "UPDATE [Courses_Students] SET [LevelId] = @levelId " +
                            "WHERE [CourseId] = @courseId AND [StudentId] = @studentId";
            Command command = new Command(sql, false);
            command.AddParameter("levelId", levelId);
            command.AddParameter("courseId", courseId);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion

        #region DELETE
        public bool Delete(int id)
        {
            string sql = "DELETE FROM [Students] " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool LeaveCourse(int studentId, int courseId)
        {
            string sql = "DELETE FROM [Courses_Students] " +
                            "WHERE [CourseId] = @courseId AND [StudentId] = @studentId";
            Command command = new Command(sql, false);
            command.AddParameter("courseId", courseId);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool LeaveGroup(int studentId, int groupId)
        {
            string sql = "DELETE FROM [Groups_Students] " +
                            "WHERE [GroupId] = @groupId AND [StudentId] = @studentId";
            Command command = new Command(sql, false);
            command.AddParameter("groupId", groupId);
            command.AddParameter("studentId", studentId);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion
    }
}

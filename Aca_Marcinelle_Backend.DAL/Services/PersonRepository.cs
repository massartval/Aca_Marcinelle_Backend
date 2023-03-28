using Aca_Marcinelle_Backend.DAL.Entities;
using Aca_Marcinelle_Backend.DAL.Interfaces;
using Aca_Marcinelle_Backend.DAL.Tools;
using System.Data.SqlClient;

namespace Aca_Marcinelle_Backend.DAL.Services
{
    public class PersonRepository : IGenericRepository<Person>
    {
        private Connection _connection;
        public PersonRepository(Connection connection)
        {
            _connection = connection;
        }

        public static Person MapPerson(SqlDataReader reader)
        {
            return new Person()
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
                PhoneNumber = (reader["PhoneNumber"] is DBNull ? null : (string?)reader["PhoneNumber"])
            };
        }

        #region SELECT
        public IEnumerable<Person> GetAll()
        {
            string sql = "SELECT * FROM [Persons]";
            Command command = new Command(sql, false);
            return _connection.ExecuteReader(command, reader => MapPerson(reader));
        }

        public Person? GetById(int id)
        {
            string sql = "SELECT * FROM [Persons] " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteReader(command, reader => MapPerson(reader)).FirstOrDefault();
        }
        #endregion

        #region INSERT
        public bool Create(Person form)
        {
            string sql = "INSERT INTO [Persons]([CategoryId], [FirstName], [LastName], [BirthDate], [City], [Street], [HouseNumber], [Zipcode], [NISS], [Email], [PhoneNumber]) " +
                            "VALUES(@categoryId, @firstName, @lastName, @birthDate, @city, @street, @houseNumber, @zipcode, @NISS, @email, @phoneNumber)";
            Command command = new Command(sql, false);
            command.AddParameter("categoryId", (form.CategoryId is null ? DBNull.Value : form.CategoryId));
            command.AddParameter("firstName", form.FirstName);
            command.AddParameter("lastName", form.LastName);
            command.AddParameter("birthDate", form.BirthDate);
            command.AddParameter("city", form.City);
            command.AddParameter("street", form.Street);
            command.AddParameter("houseNumber", form.HouseNumber);
            command.AddParameter("zipcode", (form.Zipcode is null ? DBNull.Value : form.Zipcode));
            command.AddParameter("NISS", form.NISS);
            command.AddParameter("email", (form.Email is null ? DBNull.Value : form.Email));
            command.AddParameter("phoneNumber", (form.PhoneNumber is null ? DBNull.Value : form.PhoneNumber));
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion

        #region UPDATE
        public bool Update(Person form)
        {
            string sql = "UPDATE [Persons] " +
                            "SET [CategoryId] = @categoryId, [FirstName] =  @firstName, [LastName] = @lastName, [BirthDate] = @birthDate, [City] = @city, [Street] = @street, [HouseNumber] = @houseNumber, [Zipcode] = @zipcode, [NISS] = @NISS, [Email] = @email, [PhoneNumber] = @phoneNumber " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", form.Id);
            command.AddParameter("categoryId", (form.CategoryId is null ? DBNull.Value : form.CategoryId));
            command.AddParameter("firstName", form.FirstName);
            command.AddParameter("lastName", form.LastName);
            command.AddParameter("birthDate", form.BirthDate);
            command.AddParameter("city", form.City);
            command.AddParameter("street", form.Street);
            command.AddParameter("houseNumber", form.HouseNumber);
            command.AddParameter("zipcode", (form.Zipcode is null ? DBNull.Value : form.Zipcode));
            command.AddParameter("NISS", form.NISS);
            command.AddParameter("email", (form.Email is null ? DBNull.Value : form.Email));
            command.AddParameter("phoneNumber", (form.PhoneNumber is null ? DBNull.Value : form.PhoneNumber));
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion

        #region DELETE
        public bool Delete(int id)
        {
            string sql = "DELETE FROM [Persons] " +
                            "WHERE [Id] = @id";
            Command command = new Command(sql, false);
            command.AddParameter("id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }
        #endregion
    }
}

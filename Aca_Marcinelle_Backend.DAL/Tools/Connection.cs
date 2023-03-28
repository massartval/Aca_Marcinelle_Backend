using System.Data;
using System.Data.SqlClient;

namespace Aca_Marcinelle_Backend.DAL.Tools
{
    public class Connection
    {
        private readonly string _connectionString;
        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        private static SqlCommand CreateCommand(SqlConnection sqlConnection, Command command)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = command.Query;

            if (command.IsStoredProcedure) sqlCommand.CommandType = CommandType.StoredProcedure;
            
            foreach(KeyValuePair<string, object> parameter in command.Parameters)
            {
                SqlParameter sqlParameter = sqlCommand.CreateParameter();
                sqlParameter.ParameterName = parameter.Key;
                sqlParameter.Value = parameter.Value;
                sqlCommand.Parameters.Add(sqlParameter);
            }

            return sqlCommand;
        }
        public int ExecuteNonQuery(Command command)
        {
            using(SqlConnection sqlConnection = CreateConnection(_connectionString))
            {
                using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public object? ExecuteScalar(Command command) 
        {
            using(SqlConnection sqlConnection = CreateConnection(_connectionString))
            {
                using(SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    object? result = sqlCommand.ExecuteScalar();
                    return (result is DBNull) ? null : result;
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<SqlDataReader, TResult> selector)
        {
            ArgumentNullException.ThrowIfNull(selector);
            using(SqlConnection sqlConnection = CreateConnection(_connectionString))
            {
                using(SqlCommand sqlCommand = CreateCommand(sqlConnection, command)) 
                {
                    sqlConnection.Open();
                    using(SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            yield return selector(reader);
                        }
                    }
                }
            }
        }

        //public DataTable GetDataTable(Command command)
        //{
        //    using(SqlConnection sqlConnection = CreateConnection(_connectionString))
        //    {
        //        using (SqlCommand sqlCommand = CreateCommand(sqlConnection, command))
        //        {
        //            using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
        //            {
        //                sqlDataAdapter.SelectCommand = sqlCommand;
        //                DataTable dataTable = new DataTable();
        //                sqlDataAdapter.Fill(dataTable);
        //                return dataTable;
        //            }
        //        }
        //    } 
        //}
    }
}

using Olympics.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class SportDBService
    {
        private SqlConnection _connection;

        public SportDBService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<SportModel> GetSports()
        {
            List<SportModel> countries = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT Id, Name, TeamActivity FROM dbo.SportTable;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new SportModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    TeamActivity = reader.GetBoolean(2)
                });
            }

            _connection.Close();

            return (countries);
        }

        public void NewCountry(SportModel model)
        {
            _connection.Open();

            string insertText = $"insert into dbo.SportTable (Name, TeamActivity) values('{model.Name}', '{model.TeamActivity}'); ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}

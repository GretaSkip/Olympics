using Olympics.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class AthleteDBService
    {
        private SqlConnection _connection;

        public AthleteDBService(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<AthleteModel> ShowAthletes()
        {
            List<AthleteModel> athletes = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT Id, Name, Surname, Country FROM dbo.AthleteTable;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athletes.Add(new AthleteModel()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Country = reader.GetString(3),
                });
            }

            _connection.Close();

            return (athletes);
        }

        public void NewAthlete(AthleteModel model)
        {
            _connection.Open();

            string insertText = $"insert into dbo.AthleteTable (Name, Surname, Country) values('{model.Name}', '{model.Surname}', '{model.Country}'); ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

        }

    }
}

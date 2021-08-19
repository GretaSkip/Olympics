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

        public List<AthleteModel> GetAthletes()
        {
            List<AthleteModel> athletes = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT * FROM dbo.AthletesWithCountriesSports;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                athletes.Add(new AthleteModel()
                {
                    Id = reader.GetInt32(2),
                    Name = reader.GetString(3),
                    Surname = reader.GetString(4),
                    Country_Id = reader.GetInt32(5),
                    CountryName = reader.GetString(6),
                    SportName = reader.GetString(7),
                });
            }

            _connection.Close();

            return (athletes);
        }

        public void NewAthlete(AthleteModel model)
        {
            _connection.Open();

            string insertText = $"insert into dbo.AthleteTable (Name, Surname, Country_Id) values('{model.Name}', '{model.Surname}', '{model.Country_Id}'); ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

        }

    }
}

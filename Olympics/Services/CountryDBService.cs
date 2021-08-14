using Olympics.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class CountryDBService
    {
        private SqlConnection _connection;

        public CountryDBService(SqlConnection connection)
        {
            _connection = connection;
        }

       
        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countries = new();

            _connection.Open();

            using var command = new SqlCommand("SELECT Id, CountryName, ISO3 FROM dbo.CountryTable;", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                countries.Add(new CountryModel()
                {
                    Id = reader.GetInt32(0),
                    CountryName = reader.GetString(1),
                    ISO3 = reader.GetString(2)
                });
            }

            _connection.Close();

            return (countries);
        }

        public void NewCountry(CountryModel model)
        {
            _connection.Open();

            string insertText = $"insert into dbo.CountryTable (CountryName, ISO3) values('{model.CountryName}', '{model.ISO3}'); ";

            SqlCommand command = new SqlCommand(insertText, _connection);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}

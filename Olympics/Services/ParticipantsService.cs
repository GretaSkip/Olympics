using Olympics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Services
{
    public class ParticipantsService
    {
        public AthleteDBService _athleteDB;
        public CountryDBService _countryDB;
        public SportDBService _sportDB;

        public ParticipantsService(AthleteDBService athleteDB, CountryDBService countryDB, SportDBService sportDB)
        {
            _athleteDB = athleteDB;
            _countryDB = countryDB;
            _sportDB = sportDB;
        }



        public ParticipantsModel GetAll()
        {
            ParticipantsModel participants = new ParticipantsModel()
            {
                Athletes = _athleteDB.GetAthletes(),
                Countries = _countryDB.GetCountries(),
                Sports = _sportDB.GetSports()

            };

            return participants;


        }

        public ParticipantsModel AddNew()
        {
            List<AthleteModel> athletesList = new();
            athletesList.Add(new AthleteModel());

            ParticipantsModel participants = new ParticipantsModel()
            {
                Athletes = athletesList,
                Countries = _countryDB.GetCountries(),
                Sports = _sportDB.GetSports()

            };

            return participants;


        }
    }
}

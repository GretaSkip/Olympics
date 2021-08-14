using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public class AthleteController : Controller
    {
        private ParticipantsService _participantsDB;

        private AthleteDBService _athleteDB;

        private CountryDBService _countryDB;


        public AthleteController(ParticipantsService participantsDB, AthleteDBService athleteDB, CountryDBService countryDB)
        {
            _participantsDB = participantsDB;
            _athleteDB = athleteDB;
            _countryDB = countryDB;
        }

        public IActionResult Index()
        {
            return View(_participantsDB.GetAll());

        }

        public IActionResult Create()
        {
            ParticipantsModel model = _participantsDB.AddNew();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(List<AthleteModel> athletes)
        {
            _athleteDB.NewAthlete(athletes[0]);

            return RedirectToAction("Index");
        }


    }
}

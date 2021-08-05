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
        private AthleteDBService _athleteDB;

        public AthleteController(AthleteDBService athleteDB)
        {
            _athleteDB = athleteDB;
        }

        public IActionResult Index()
        {
            return View(_athleteDB.ShowAthletes());

        }

        public IActionResult Create()
        {
            AthleteModel newAthlete = new();

            return View(newAthlete);
        }

        [HttpPost]
        public IActionResult Create(AthleteModel athlete)
        {
            _athleteDB.NewAthlete(athlete);

            return RedirectToAction("Index");
        }


    }
}

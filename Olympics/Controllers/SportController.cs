using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public class SportController : Controller
    {
        private SportDBService _sportDB;

        public SportController(SportDBService sportDB)
        {
            _sportDB = sportDB;
        }

        public IActionResult Index()
        {
            return View(_sportDB.GetSports());

        }

        public IActionResult Create()
        {
            SportModel newSport = new();

            return View(newSport);
        }

        [HttpPost]
        public IActionResult Create(SportModel sport)
        {
            _sportDB.NewCountry(sport);

            return RedirectToAction("Index");
        }
    }
}

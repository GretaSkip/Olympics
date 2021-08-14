using Microsoft.AspNetCore.Mvc;
using Olympics.Models;
using Olympics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public class CountryController : Controller
    {
        private CountryDBService _countryDB;

        public CountryController(CountryDBService countryDB)
        {
            _countryDB = countryDB;
        }

        public IActionResult Index()
        {
            return View(_countryDB.GetCountries());

        }

        public IActionResult Create()
        {
            CountryModel newCountry = new();

            return View(newCountry);
        }

        [HttpPost]
        public IActionResult Create(CountryModel country)
        {
            _countryDB.NewCountry(country);

            return RedirectToAction("Index");
        }


    }
}


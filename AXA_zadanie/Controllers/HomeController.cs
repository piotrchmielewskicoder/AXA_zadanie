using AXA_zadanie.Models;
using AXA_zadanie.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AXA_zadanie.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _context = context;

        }

        private readonly ILogger<HomeController> _logger;

 
        public IActionResult Index()
        {
            var list = new FilmsListViewModel(_context);
            return View(list);
        }

        public IActionResult Vote(int id)
        {
            var voteRate = new Models.FilmRating()
            {
                FilmId = id
            };
            return View(voteRate);
        }

        [HttpPost]
        public ActionResult Vote(FilmRating FilmRateIN)
        {
            _context.FilmRating.Add(new FilmRating()
            {
                Rate = FilmRateIN.Rate,
                FilmId = FilmRateIN.FilmId
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

            public IActionResult Details(int id)
        {
            var stc = new SharpTrooper.Core.SharpTrooperCore("https://swapi.dev/api", null);
            var data = stc.GetAllFilms().results.FirstOrDefault(e => e.episode_id == id);

            if (data == null) return NotFound();
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
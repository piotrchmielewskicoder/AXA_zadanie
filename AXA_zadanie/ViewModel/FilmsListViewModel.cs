using AXA_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AXA_zadanie.ViewModel
{
    public class FilmsListViewModel
    {
        public List<KeyValuePair<SharpTrooper.Entities.Film,double>> FilmsList { get; }

        public FilmsListViewModel(MyDbContext db)
        {
            FilmsList = new List<KeyValuePair<SharpTrooper.Entities.Film, double>>();
            var stc = new SharpTrooper.Core.SharpTrooperCore("https://swapi.dev/api", null);
            
                foreach (var _film in stc.GetAllFilms().results)
                {
                    var _counter = db.FilmRating.Where(e => e.FilmId == _film.episode_id).Count();
                double _rating = -1;

                    if (_counter > 0)
                    {
                        _rating = (double)db.FilmRating.Where(e => e.FilmId == _film.episode_id).Sum(e => e.Rate) / (double)_counter;
                    }

                    FilmsList.Add(new KeyValuePair<SharpTrooper.Entities.Film, double>(_film, _rating));
                }
            
        }
    }
}

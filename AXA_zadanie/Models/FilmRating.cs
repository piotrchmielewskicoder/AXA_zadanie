using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXA_zadanie.Models
{
    public class FilmRating
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int Rate { get; set; }
    }
}

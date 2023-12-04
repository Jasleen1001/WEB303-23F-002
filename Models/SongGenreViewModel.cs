using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Jasleen.Models
{

    public class SongGenreViewModel
    {
        public List<Song> Song { get; set; }
        public SelectList Genres { get; set; }
        public string SongGenre { get; set; }
        public string SearchString { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

// This class is for searching by 'Genre'
namespace Juice_World.Models
{
    public class JuiceGenreViewModel
    {
        public List<Juice>? Juices { get; set; }
        public SelectList? Genres { get; set; }
        public string? JuiceGenre { get; set; }
        public string? SearchString { get; set; }
    }
}

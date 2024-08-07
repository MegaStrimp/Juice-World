using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

// This class is for searching by 'Type'
namespace Juice_World.Models
{
    public class JuiceTypeViewModel
    {
        public List<Juice>? Juices { get; set; }
        public List<Juice>? JuicesReverse { get; set; }
        public SelectList? Types { get; set; }
        public string? JuiceType { get; set; }
        public string? SearchString { get; set; }
    }
}

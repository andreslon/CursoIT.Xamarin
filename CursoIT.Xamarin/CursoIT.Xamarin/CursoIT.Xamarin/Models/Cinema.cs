using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIT.Xamarin.Models
{
    public class Cinema
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? likes { get; set; }
        public int? dislikes { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }
}

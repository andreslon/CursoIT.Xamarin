using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIT.Xamarin.Views
{

    public class MenuItem
    {
        public MenuItem()
        {
           
        }
        public int Id { get; set; }
        public string Title { get; set; } 

        public Type TargetType { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoIT.Xamarin.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Name = "Pepa pig";
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}

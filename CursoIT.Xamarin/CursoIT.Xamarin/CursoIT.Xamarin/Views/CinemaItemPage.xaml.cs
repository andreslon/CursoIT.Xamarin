using CursoIT.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursoIT.Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CinemaItemPage : ContentPage
	{  
        public CinemaItemPage(CinemaItemViewModel selectedVM)
        {
            InitializeComponent();
            BindingContext = selectedVM;
        }
    }
}
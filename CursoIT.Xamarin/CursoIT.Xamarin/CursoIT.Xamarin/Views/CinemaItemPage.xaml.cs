using CursoIT.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
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

            var position = new Position(selectedVM.latitude, selectedVM.longitude);
            itemMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = selectedVM.Name,
            });

            itemMap.MoveToRegion(MapSpan.FromCenterAndRadius(position
                , Distance.FromKilometers(1)));
        }
    }
}
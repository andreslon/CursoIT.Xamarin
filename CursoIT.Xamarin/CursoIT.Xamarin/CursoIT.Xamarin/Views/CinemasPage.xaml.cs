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
    public partial class CinemasPage : ContentPage
    {
        public CinemasPage()
        {
            InitializeComponent();
            BindingContext = new CinemasViewModel();
            lstCinemas.ItemTapped += LstCinemas_ItemTapped;
        }

        async private void LstCinemas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedVM = (CinemaItemViewModel)lstCinemas.SelectedItem;
            await this.Navigation.PushAsync(new CinemaItemPage(selectedVM));
        } 
    }
}
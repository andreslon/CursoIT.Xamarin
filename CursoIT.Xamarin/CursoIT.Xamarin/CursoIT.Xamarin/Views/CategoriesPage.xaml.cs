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
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModels.CategoryViewModel();

            stkContent.Children.Add(new Entry
            {
                Placeholder = "Edad"
            });

            myBtn.Clicked += MyBtn_Clicked;
        }
        async private void MyBtn_Clicked(object sender, EventArgs e)
        {
            var mybtn = (Button)sender;
            mybtn.BackgroundColor = Color.Blue;

            await DisplayAlert("Notificación",
                $"Su descripción es: {DescriptionTxt.Text}", "Ok");
        }
    }
}
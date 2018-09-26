using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Naxam.Controls.Forms;
namespace CursoIT.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : BottomTabbedPage
    {
        public HomePage ()
        {
            InitializeComponent();
        }
    }
}
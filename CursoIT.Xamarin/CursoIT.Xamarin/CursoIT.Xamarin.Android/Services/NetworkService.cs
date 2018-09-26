using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if __Droid__
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
#else 

#endif
namespace CursoIT.Xamarin.Droid.Services
{
    class NetworkService
    {
        public void Check()
        {

            Console.Write("verificar conexion");

            string name = string.Empty;
        }
    }
}
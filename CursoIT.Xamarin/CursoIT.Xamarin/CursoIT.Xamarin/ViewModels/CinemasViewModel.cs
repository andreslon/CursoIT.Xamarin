using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CursoIT.Xamarin.ViewModels
{
    public class CinemasViewModel : BaseViewModel
    {
        public ObservableCollection<Cinema> Cinemas { get; set; }
        public ICinemaRepository CinemaRepository { get; set; }
        public CinemasViewModel()
        {
            CinemaRepository = DependencyService.Get<ICinemaRepository>();
            LoadData();
        }
        async private void LoadData()
        {
            try
            {
                Cinemas = new ObservableCollection<Cinema>();
                var list = await CinemaRepository.GetCinemas();
                foreach (var item in list)
                {
                    Cinemas.Add(item);
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}

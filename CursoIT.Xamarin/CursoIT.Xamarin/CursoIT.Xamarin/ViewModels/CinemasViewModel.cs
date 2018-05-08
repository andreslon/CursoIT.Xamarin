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
        public ObservableCollection<CinemaItemViewModel> Cinemas { get; set; }
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
                Cinemas = new ObservableCollection<CinemaItemViewModel>();
                var list = await CinemaRepository.GetCinemas();
                foreach (var item in list)
                {
                    Cinemas.Add(new CinemaItemViewModel {
                        Description= item.Description,
                        Dislikes = item.dislikes.GetValueOrDefault(),
                        id = item.id,
                        Image = item.Image,
                        latitude = item.latitude.GetValueOrDefault(),
                        Likes = item.likes.GetValueOrDefault(),
                        longitude = item.longitude.GetValueOrDefault(),
                        Name = item.Name  
                    });
                }
            }
            catch (Exception ex)
            {

            } 
        } 
    }
}

using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Logic;
using CursoIT.Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoIT.Xamarin.ViewModels
{
    public class CinemasViewModel : BaseViewModel
    {
        public ObservableCollection<CinemaItemViewModel> Cinemas { get; set; } 

        public ICinemaRepository CinemaRepository { get; set; }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set
            {
                _IsLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public CinemasViewModel()
        {
            CinemaRepository = DependencyService.Get<ICinemaRepository>();
            LoadData();
        }
        public ICommand LoadDataCommand
        {
            get { return new RelayCommand(LoadData, null); }
        }
        async private void LoadData()
        {
            IsLoading = true;
            Cinemas = new ObservableCollection<CinemaItemViewModel>();
            var list = await CinemaRepository.GetCinemas();
            if (list.Any())
                list = list.OrderBy(x => x.Name).ToList();

            foreach (var item in list)
            {
                Cinemas.Add(new CinemaItemViewModel
                {
                    Description = item.Description,
                    Dislikes = item.dislikes.GetValueOrDefault(),
                    id = item.id,
                    Image = item.Image,
                    latitude = item.latitude.GetValueOrDefault(),
                    Likes = item.likes.GetValueOrDefault(),
                    longitude = item.longitude.GetValueOrDefault(),
                    Name = item.Name
                });
                OnPropertyChanged("Cinemas");
            }
            IsLoading = false;
        }
    }
}

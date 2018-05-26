using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoIT.Xamarin.ViewModels
{
    public class CinemaItemViewModel : BaseViewModel
    {
        public ICinemaRepository CinemaRepository { get; set; }
        public CinemaItemViewModel()
        {
            CinemaRepository = DependencyService.Get<ICinemaRepository>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        private int likes;
        public int Likes
        {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged("Likes");
            }
        }
        private int dislikes;
        public int Dislikes
        {
            get { return dislikes; }
            set
            {
                dislikes = value;
                OnPropertyChanged("Dislikes");
            }
        }


        public ICommand LikeCommand
        {
            get { return new RelayCommand(Like, null); }
        }
        private void Like()
        {
            this.Likes++;
            Update();
        }
        public ICommand DislikeCommand
        {
            get { return new RelayCommand(Dislike, null); }
        }
        private void Dislike()
        {
            this.Dislikes++;
            Update();
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }


        async private void Update()
        {
            try
            {
                IsLoading = true;
                var response = await CinemaRepository.PutCinema(new Models.Cinema
                {
                    id = this.id,
                    Description = this.Description,
                    dislikes = this.dislikes,
                    Image = this.Image,
                    latitude = this.latitude,
                    likes = this.likes,
                    longitude = this.longitude,
                    Name = this.Name
                });
                if (!response)
                {
                    await App.Current.MainPage.DisplayAlert
                   ("Error actualizando el cinema"
                   , "Ha ocurrido enviando la solicitud al Api", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert
                    ("Error actualizando el cinema", ex.Message, "Aceptar");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}

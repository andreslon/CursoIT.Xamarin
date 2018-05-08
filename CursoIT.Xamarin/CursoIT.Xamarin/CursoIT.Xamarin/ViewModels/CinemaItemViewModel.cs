﻿using CursoIT.Xamarin.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CursoIT.Xamarin.ViewModels
{
    public class CinemaItemViewModel : BaseViewModel
    { 
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
        }
        public ICommand DislikeCommand
        {
            get { return new RelayCommand(Dislike, null); }
        }
        private void Dislike()
        {
            this.Dislikes++;
        }
    }
}

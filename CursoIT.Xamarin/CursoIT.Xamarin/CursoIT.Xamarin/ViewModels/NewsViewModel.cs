using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.Logic;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoIT.Xamarin.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        public NewsViewModel()
        {
            this.Name = "Andres";
            LoadData();
        }

        async private void LoadData()
        {
            IsLoading = true;
            await Task.Delay(5000);
            IsLoading = false;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }

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
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }


        public ICommand ClearCommand
        {
            get { return new RelayCommand(Clear, null); }
        }

        private void Clear()
        {
            DependencyService.Get<ITextToSpeech>().Speak(this.Description);

            this.Description = string.Empty;
        }

    }
}

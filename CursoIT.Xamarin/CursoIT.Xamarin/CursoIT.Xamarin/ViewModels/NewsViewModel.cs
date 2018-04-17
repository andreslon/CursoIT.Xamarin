using CursoIT.Xamarin.Logic;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CursoIT.Xamarin.ViewModels
{
    class NewsViewModel : INotifyPropertyChanged
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

        async private void Clear()
        {
            await CrossTextToSpeech.Current.Speak(Description);
            this.Description = string.Empty;
        }



        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

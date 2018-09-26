using CursoIT.Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CursoIT.Xamarin.ViewModels
{
    class MenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>(new[]
            {
                    new MenuItem { Id = 0, Title = "Inicio"  , TargetType=typeof(HomePage)},
                    new MenuItem { Id = 1, Title = "Opciones", TargetType=typeof(OptionsPage) },
                    new MenuItem { Id = 1, Title = "Perfil",TargetType=typeof(AccountPage) }
                });
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

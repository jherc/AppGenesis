namespace AppGenesis.Models
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using ViewModels;
    public class Materia
    {
        #region Properties
        public int IdMateria { get; set; }

        public string Nrc { get; set; }

        public string Nombre { get; set; }

        public List<Nota> Notas { get; set; }
        #endregion

        public override string ToString()
        {
            return Nombre;
        }

        #region Commands
        public ICommand SelectMateriaCommand
        {
            get
            {
                return new RelayCommand(SelectMateria);
            }
        }

        async void SelectMateria()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Notas = new NotasViewModel(Notas);
            await Application.Current.MainPage.Navigation.PushAsync(
               new NotasView());
        }
        #endregion


    }
}

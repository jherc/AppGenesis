namespace AppGenesis.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;

    public class NotasViewModel
    {
        #region Properties
        public ObservableCollection<Nota> Notas
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public NotasViewModel()
        {
            LoadNotas();
        }
        #endregion

        #region Methods
        void LoadNotas()
        {

        }
        #endregion
    }
}

namespace AppGenesis.ViewModels
{
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    public class NotasViewModel : INotifyPropertyChanged
    {
        #region Attributes
        List<Nota> notas;

        ObservableCollection<Nota> _notas;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<Nota> Notas
        {
            get
            {
                return _notas;
            }
            set
            {
                if (_notas != value)
                {
                    _notas = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Notas)));
                }
            }
        }
        #endregion

        #region Constructors
        public NotasViewModel(List<Nota> notas)
        {
            this.notas = notas;

            Notas = new ObservableCollection<Nota>(notas.OrderBy(p => p.Corte));
        }
        #endregion

        #region Methods
        void LoadNotas()
        {

        }
        #endregion
    }
}

namespace AppGenesis.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using Services;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;

    public class MateriasViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Attributes
        ObservableCollection<Materia> _materias;
        #endregion

        #region Properties
        public ObservableCollection<Materia> MateriasList
        {
            get
            {
                return _materias;
            }
            set
            {
                if(_materias != value)
                {
                    _materias = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(MateriasList)));
                }
            }
        }
        #endregion

        #region Constructors
        public MateriasViewModel()
        {
            apiService = new ApiService();

            dialogService = new DialogService();

            LoadMaterias();
        }
        #endregion

        #region Methods
        async void LoadMaterias()
        {
            var connection = await apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    connection.Message);
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.GetList<Materia>(
                "http://appnesis-001-site1.btempurl.com",
                "/api",
                "/Materias",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken);

            if(!response.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                    response.Message);
                return;
            }

            var materias = (List<Materia>)response.Result;

            MateriasList = new ObservableCollection<Materia>(materias.OrderBy(c => c.Nombre));
        }
        #endregion
    }
}

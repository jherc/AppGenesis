namespace AppGenesis.API.Models
{
    using System.Collections.Generic;

    public class MateriaResponse
    {
        public int IdMateria { get; set; }

        public string Nrc { get; set; }

        public string Nombre { get; set; }

        public List<NotaResponse> Notas { get; set; }

    }
}
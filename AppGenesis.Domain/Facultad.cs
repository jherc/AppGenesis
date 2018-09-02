namespace AppGenesis.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Facultad
    {
        [Key]
        public int IdFacultad { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string NombreFacultad { get; set; }

        [JsonIgnore]
        public virtual ICollection<Materia> Materias { get; set; }
    }
}


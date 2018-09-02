namespace AppGenesis.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Materia
    {
        [Key]
        public int IdMateria { get; set; }

        public int IdFacultad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Nrc { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Nota> Notas { get; set; }

        [JsonIgnore]
        public virtual Facultad Facultad { get; set; }

    }
}



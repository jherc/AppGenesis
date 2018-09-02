namespace AppGenesis.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Nota
    {
        [Key]
        public int IdNota { get; set; }

        public int IdMateria { get; set; }

        public int IdUsuario { get; set; }


        [MaxLength(10, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Nnota { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Corte { get; set; }


        [JsonIgnore]
        public virtual Materia Materia { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

    }
}
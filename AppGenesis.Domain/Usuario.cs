namespace AppGenesis.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.")]
        [Index("App_Email_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(20, ErrorMessage = "El campo {0} solo puede tener {1} caracteres.", MinimumLength = 4)]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual ICollection<Nota> Notas { get; set; }
    }
}


namespace AppGenesis.Domain
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<AppGenesis.Domain.Facultad> Facultads { get; set; }

        public System.Data.Entity.DbSet<AppGenesis.Domain.Materia> Materias { get; set; }

        public System.Data.Entity.DbSet<AppGenesis.Domain.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<AppGenesis.Domain.Nota> Notas { get; set; }
    }
}

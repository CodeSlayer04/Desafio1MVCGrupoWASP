using Microsoft.EntityFrameworkCore;

namespace Desafio1MVCGrupoWASP.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

    }
}

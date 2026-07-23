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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí configuramos el Data Seeding
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nombre = "Recursos Humanos", Descripcion = "Área de RRHH" },
                new Departamento { Id = 2, Nombre = "Tecnología", Descripcion = "Área de TI" },
                new Departamento { Id = 3, Nombre = "Ventas", Descripcion = "Área comercial" }
            );

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado 
                { 
                    ID = 1, 
                    Nombre = "John Doe", 
                    FechaNacimiento = DateOnly.Parse("1985-05-20"), 
                    FechaContratacion = DateOnly.Parse("2010-08-15"), 
                    Salario = 50000, 
                    DepartamentoId = 1
                },
                new Empleado 
                { 
                    ID = 2, 
                    Nombre = "Jane Smith", 
                    FechaNacimiento = DateOnly.Parse("1990-03-10"), 
                    FechaContratacion = DateOnly.Parse("2015-01-25"), 
                    Salario = 70000, 
                    DepartamentoId = 2 
                },
                new Empleado 
                { 
                    ID = 3, 
                    Nombre = "Mark Johnson", 
                    FechaNacimiento = DateOnly.Parse("1982-11-22"), 
                    FechaContratacion = DateOnly.Parse("2012-06-18"), 
                    Salario = 55000, 
                    DepartamentoId = 3 
                },
                new Empleado 
                { 
                    ID = 4, 
                    Nombre = "Emily Davis", 
                    FechaNacimiento = DateOnly.Parse("1978-07-30"), 
                    FechaContratacion = DateOnly.Parse("2005-10-12"), 
                    Salario = 75000, 
                    DepartamentoId = 1 
                },
                new Empleado 
                { 
                    ID = 5, 
                    Nombre = "Michael Brown", 
                    FechaNacimiento = DateOnly.Parse("1995-12-05"), 
                    FechaContratacion = DateOnly.Parse("2020-04-15"), 
                    Salario = 60000, 
                    DepartamentoId = 2 
                }
            );
        }



    }
}

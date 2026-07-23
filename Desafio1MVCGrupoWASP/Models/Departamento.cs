using System.ComponentModel.DataAnnotations;

namespace Desafio1MVCGrupoWASP.Models
{
    public class Departamento
    {
        // Código único de departamento (Primary Key)
        [Key]
        public int Id { get; set; }

        // Nombre: Obligatorio, longitud mínima 3 y máxima 100 caracteres.
        [Required(ErrorMessage = "El nombre del departamento es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        [Display(Name = "Nombre del Departamento")]
        public string Nombre { get; set; } = string.Empty;

        // Descripción: Opcional (se permite nulo o vacío)
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        // Propiedad de navegación: Un departamento tiene muchos empleados (1 a N)
        public virtual ICollection<Empleado>? Empleados { get; set; }
    }
}
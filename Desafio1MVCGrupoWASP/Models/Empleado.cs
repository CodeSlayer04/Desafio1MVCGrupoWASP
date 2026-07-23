using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio1MVCGrupoWASP.Models
{
    public class Empleado
    {
        // Código único del empleado (Primary Key)
        [Key]
        public int ID { get; set; }

        // Nombre: Obligatorio, longitud mínima 2 y máxima 100 caracteres.
        [Required(ErrorMessage = "El nombre del empleado es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        // Fecha de nacimiento: Obligatoria y fecha válida
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        // Fecha de contratación: Obligatoria y fecha válida
        [Required(ErrorMessage = "La fecha de contratación es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Contratación")]
        public DateOnly FechaContratacion { get; set; }

        // Salario: Obligatorio, no permite valores negativos ni cero
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario debe ser mayor a cero.")]
        [Column(TypeName = "decimal(18,2)")] // Define precisión adecuada para moneda en SQL Server
        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        // Descripción: Opcional
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        // Clave Foránea hacia Departamento
        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        // Propiedad de navegación hacia el modelo Departamento
        [ForeignKey("DepartamentoId")]
        public virtual Departamento? Departamento { get; set; }
    }
}
namespace Desafio1MVCGrupoWASP.Models
{
    public class Empleado
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public DateOnly FechaContratacion {  get; set; }
        public decimal Salario { get; set; }
        public string Descripcion { get; set; }

    }
}

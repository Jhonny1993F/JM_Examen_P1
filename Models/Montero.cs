namespace JM_Examen_P1.Models
{
    public class Montero
    {
        public int Id { get; set; }
        public int JM_SemestreId { get; set; }
        public double JM_Nota { get; set; }
        public string? JM_Nombre { get; set; }
        public bool JM_Estudiante { get; set; }
        public DateTime JM_Fecha { get; set; }
    }
}

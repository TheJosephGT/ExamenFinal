using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paquete{

    [Key]
    public int PaqueteId { get; set; }
    [Required(ErrorMessage ="La fecha es requerida.")]
    public DateOnly Fecha { get; set; }
    [Required(ErrorMessage ="El descripcion es requerida.")]
    public string? Descripcion { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad {get; set;}
    
    [ForeignKey("PaqueteId")]
    public virtual List<DetallePaquetes> DetallePaquetes {get; set;} = new List<DetallePaquetes>();
}
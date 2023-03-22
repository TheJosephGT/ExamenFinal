using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paquete{

    [Key]
    public int PaqueteId { get; set; }
    [Required(ErrorMessage ="La fecha es requerida.")]
    public DateOnly Fecha { get; set; }
    [Required(ErrorMessage ="El descripcion es requerida.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage ="La cantidad es requerida.")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage ="La ProductoId es requerida.")]
    public int ProductoId { get; set;}
    
    [ForeignKey("DetallePaqueteId")]
    public virtual List<DetallePaquetes> DetallePaquetes {get; set;} = new List<DetallePaquetes>();
}
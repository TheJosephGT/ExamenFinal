using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paquete{

    [Key]
    public int PaqueteId { get; set; }
    [Required(ErrorMessage ="La fecha es requerida.")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage ="El descripcion es requerida.")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage ="El productoId es requerida.")]
    public int ProductoId { get; set; }
    [Range(0, 10000000, ErrorMessage = "La cantidad es requerida.")]
    public int Cantidad {get; set;}
    
    [ForeignKey("PaqueteId")]
    public virtual List<DetallePaquetes> DetallePaquetes {get; set;} = new List<DetallePaquetes>();
}
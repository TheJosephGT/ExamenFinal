using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paquete{

    [Key]
    public int PaqueteId { get; set; }
    public DateOnly Fecha { get; set; }
    public int ProductoId { get; set; }
    public string? NombreCliente { get; set; }

    
    [ForeignKey("ProductoId")]
    public virtual List<Productos> Productos {get; set;} = new List<Productos>();

}
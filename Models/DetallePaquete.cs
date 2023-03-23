using System.ComponentModel.DataAnnotations;

public class DetallePaquetes{
    
    [Key]
    public int DetallePaqueteId { get; set; }
    public int PaqueteId { get; set; }
    public int ProductoId { get; set; }
    public int CantidadPaquete { get; set; }
}
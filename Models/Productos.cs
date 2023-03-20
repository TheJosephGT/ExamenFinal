using System.ComponentModel.DataAnnotations;

public class Productos{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "La descripcion es requerida")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El costo es requerida")]
    public double Costo { get; set; }

    [Required(ErrorMessage = "El precio es requerida")]
    public double Precio { get; set; }

    [Required(ErrorMessage = "La existencia es requerida")]
    public int Existencia { get; set; }
}
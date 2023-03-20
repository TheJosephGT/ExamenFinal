using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext{
    public DbSet<Productos> Productos {get;set;}
    public DbSet<Paquete> Paquete { get; set; }
    public Contexto (DbContextOptions<Contexto> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 1,
                Descripcion = "Maní",
                Costo = 300,
                Precio = 10,
                Existencia = 3
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 2,
                Descripcion = "Pistachos",
                Costo = 300,
                Precio = 28,
                Existencia = 5
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 3,
                Descripcion = "Ciruelas",
                Costo = 250,
                Precio = 50,
                Existencia = 3
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 4,
                Descripcion = "Pasas",
                Costo = 350,
                Precio = 100,
                Existencia = 25
            }
        );
        modelBuilder.Entity<Productos>().HasData(
            new Productos{
                ProductoId = 5,
                Descripcion = "Arándanos",
                Costo = 250,
                Precio = 10,
                Existencia = 15
            }
        );
    }
}

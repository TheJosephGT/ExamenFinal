using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext{
    public DbSet<Productos> Productos {get;set;}
    public Contexto (DbContextOptions<Contexto> options): base(options){}
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class ProductosBLL
{
    private Contexto _contexto;

    public ProductosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int productoId)
    {
        return _contexto.Productos.Any(o => o.ProductoId == productoId);
    }

    private bool Insertar(Productos producto)
    {
        _contexto.Productos.Add(producto);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Productos producto)
    {
        var existe = _contexto.Productos.Find(producto.ProductoId);
        if (existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(producto);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Productos producto)
    {
        if (!Existe(producto.ProductoId))
            return this.Insertar(producto);
        else
            return this.Modificar(producto);
    }

    public Productos? Buscar(int productoId)
    {
        return _contexto.Productos.Where(o => o.ProductoId == productoId).AsNoTracking().SingleOrDefault();
    }

    public bool Eliminar(int productoId)
    {
        var eliminado = _contexto.Productos.Where(o => o.ProductoId == productoId).SingleOrDefault();

        if (eliminado != null)
        {
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
    {
        return _contexto.Productos.AsNoTracking().Where(criterio).ToList();
    }
} 
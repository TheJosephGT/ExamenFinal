using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PaqueteBLL
{
    private Contexto _contexto;

    public PaqueteBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int paqueteId)
    {
        return _contexto.Paquete.Any(o => o.PaqueteId == paqueteId);
    }

    private bool Insertar(Paquete paquete)
    {
        _contexto.Paquete.Add(paquete);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Paquete paquete)
    {
        var existe = _contexto.Paquete.Find(paquete.PaqueteId);
        if (existe != null)
        {
            _contexto.Entry(existe).CurrentValues.SetValues(paquete);
            return _contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Paquete paquete)
    {
        if (!Existe(paquete.PaqueteId))
            return this.Insertar(paquete);
        else
            return this.Modificar(paquete);
    }

    public Paquete? Buscar(int paqueteId)
    {
        return _contexto.Paquete.Where(o => o.PaqueteId == paqueteId).AsNoTracking().SingleOrDefault();
    }

    public bool Eliminar(int paqueteId)
    {
        var eliminado = _contexto.Paquete.Where(o => o.PaqueteId == paqueteId).SingleOrDefault();

        if (eliminado != null)
        {
            _contexto.Entry(eliminado).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    void InsertarDetalle(Paquete paquete)
    {
        if (paquete.Productos != null)
        {
            foreach (var item in paquete.Productos)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);
                if (producto != null)
                {
                    _contexto.Entry(producto).State = EntityState.Modified;
                    _contexto.SaveChanges();
                }
            }
        }
    }

    void ModificarDetalle(Paquete paquete)
    {
        var productoActual = _contexto.Productos.AsNoTracking().Where(d => d.ProductoId == paquete.ProductoId).ToList();
        foreach (var item in paquete.Productos)
        {
            var producto = _contexto.Productos.Find(item.ProductoId);
            if (producto != null)
            {
                _contexto.Entry(producto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
        }
    }

    public List<Paquete> GetList(Expression<Func<Paquete, bool>> criterio)
    {
        return _contexto.Paquete.AsNoTracking().Where(criterio).ToList();
    }
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class PaqueteBLL
{
    private Contexto _contexto;
    private ProductosBLL productosBLL;

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
        InsertarDetalle(paquete);
        _contexto.Paquete.Add(paquete);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar(Paquete paquete)
    {
        ModificarDetalle(paquete);
        _contexto.Entry(paquete).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
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
        return _contexto.Paquete.Include(o => o.DetallePaquetes).Where(o => o.PaqueteId == paqueteId).SingleOrDefault();
    }

    public bool Eliminar(int paqueteId)
    {
        var eliminar = _contexto.Paquete.Where(o => o.PaqueteId == paqueteId).SingleOrDefault();

        if (eliminar != null)
        {
            foreach (var item in eliminar.DetallePaquetes)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);
                if (producto != null)
                {
                    producto.Existencia += item.CantidadPaquete;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    _contexto.SaveChanges();
                }
            }

            var Producido = _contexto.Productos.Find(eliminar.ProductoId);
            if (eliminar.Cantidad != 0 && Producido != null)
            {
                Producido.Existencia -= eliminar.Cantidad;
                _contexto.Entry(Producido).State = EntityState.Modified;
                _contexto.SaveChanges();
            }

            _contexto.RemoveRange(eliminar.DetallePaquetes);
            _contexto.Entry(eliminar).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        return false;
    }

    void InsertarDetalle(Paquete paquete)
    {
        if (paquete.DetallePaquetes != null)
        {
            foreach (var item in paquete.DetallePaquetes)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);

                if (producto != null)
                {
                    producto.Existencia -= item.CantidadPaquete;
                    _contexto.Entry(producto).State = EntityState.Modified;
                }
            }
            _contexto.SaveChanges();
        }

        var AumentarProducido = _contexto.Productos.Find(paquete.ProductoId);
        if (paquete.Cantidad != 0 && AumentarProducido != null)
        {
            AumentarProducido.Existencia += paquete.Cantidad;
            _contexto.Entry(AumentarProducido).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }

    void ModificarDetalle(Paquete paquete)
    {
        var paqueteAnterior = _contexto.Paquete.Where(o => o.PaqueteId == paquete.PaqueteId).Include(o => o.DetallePaquetes).AsNoTracking().SingleOrDefault();

        var AumentarProducido = _contexto.Productos.Find(paquete.ProductoId);
        if (paquete.Cantidad != 0 && AumentarProducido != null)
        {
            AumentarProducido.Existencia += paquete.Cantidad;
            _contexto.Entry(AumentarProducido).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        if (paqueteAnterior != null)
        {
            foreach (var item in paqueteAnterior.DetallePaquetes)
            {
                var producto = _contexto.Productos.Find(item.ProductoId);
                if (producto != null)
                {
                    producto.Existencia += item.CantidadPaquete;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    _contexto.SaveChanges();

                }
            }
        }
        foreach (var item in paquete.DetallePaquetes)
        {
            var producto = _contexto.Productos.Find(item.ProductoId);
            if (producto != null)
            {
                producto.Existencia -= item.CantidadPaquete;
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
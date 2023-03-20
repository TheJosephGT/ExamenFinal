using System.Linq.Expressions;

public class ProductosBLL
{
    private Contexto _contexto;

    public ProductosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
    {
        return _contexto.Productos.Where(criterio).ToList();
    }


}
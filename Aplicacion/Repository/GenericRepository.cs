using System.Linq.Expressions;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;
public abstract class GenericRepository<T> where T : BaseEntityA
{

    private readonly JwtManualContext _context;
    protected readonly DbSet<T> _Entities;
    public GenericRepository(JwtManualContext context)
    {
        _context = context;
        _Entities = _context.Set<T>();
    }

    public virtual void Add(T entity)
    {        
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return  _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T>? GetByIdAsync(string Id)
    {
        return (await _context.Set<T>().FindAsync(Id))!;
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class UserRepository :  IUserRepository
{

    private readonly JwtManualContext _jwtManualContext;
    public UserRepository(JwtManualContext jwtManualContext) 
    {
        _jwtManualContext = jwtManualContext;
    }
    public virtual void Add(User entity)
    {
        _jwtManualContext.Set<User>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<User> entities)
    {
        _jwtManualContext.Set<User>().AddRange(entities);
    }

    public virtual IEnumerable<User> Find(Expression<Func<User, bool>> expression)
    {
        return _jwtManualContext.Set<User>().Where(expression);
    }

    public virtual async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _jwtManualContext.Set<User>().ToListAsync();
    }

    public virtual async Task<User> GetByIdAsync(int id)
    {
        return await _jwtManualContext.Set<User>().FindAsync(id);
    }


    public virtual void Remove(User entity)
    {
        _jwtManualContext.Set<User>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<User> entities)
    {
        _jwtManualContext.Set<User>().RemoveRange(entities);
    }

    public virtual void Update(User entity)
    {
        _jwtManualContext.Set<User>()
            .Update(entity);
    }

    public virtual User FirstOrDefault(Expression<Func<User, bool>> expression)
    {
        return _jwtManualContext.Set<User>().FirstOrDefault(expression);
    }

}

    


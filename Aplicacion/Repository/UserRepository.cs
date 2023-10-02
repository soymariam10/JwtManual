using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{

    private readonly JwtManualContext _jwtManualContext;
    public UserRepository(JwtManualContext jwtManualContext) : base(jwtManualContext)
    {
        _jwtManualContext = jwtManualContext;
    }
    public Task<(int totalRegistros, IEnumerable<User> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsernameAsync(string nombre)
    {
        throw new NotImplementedException();
    }
}

    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly JwtManualContext _JwtManualContext;
        public RolRepository(JwtManualContext jwtManualContext) : base(jwtManualContext)
        {
            _JwtManualContext = jwtManualContext;
        }

        public Task<Rol> FindFirst(Expression<Func<Rol, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<(int totalRegistros, IEnumerable<Rol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Rol> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
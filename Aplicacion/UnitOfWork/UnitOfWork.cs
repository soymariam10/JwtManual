using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JwtManualContext _JwtManualContext;


        //constructor
        public UnitOfWork(JwtManualContext jwtManualContext)
        {
            _JwtManualContext = jwtManualContext;
        }

        //Repositorios
        private RolRepository _Rol;
        private UserRepository _User;

        // Propiedades de solo lectura para acceder a los repositorios
        public IRolRepository Roles => _Rol ??= new RolRepository(_JwtManualContext);
        public IUserRepository Users => _User ??= new UserRepository(_JwtManualContext);

                // Método para guardar cambios de manera asíncrona
        public Task<int> SaveAsync()
        {
            return _JwtManualContext.SaveChangesAsync();
        }

        // Método para liberar recursos
        public void Dispose()
        {
            _JwtManualContext.Dispose();
            GC.SuppressFinalize(this);

        }
    }

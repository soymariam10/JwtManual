using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
public class JwtmanualContext : DbContext{
    public JwtmanualContext(DbContextOptions<JwtmanualContext> options) : base(options){

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

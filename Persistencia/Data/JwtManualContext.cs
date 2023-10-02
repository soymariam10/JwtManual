using System.Reflection.Emit;
using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class JwtManualContext : DbContext
    {
        public JwtManualContext(DbContextOptions<JwtManualContext> options) : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;


namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50);

            builder.Property(x => x.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsUnique();
            .IsRequired();

            builder.Property(e => e.RegDate)
            .HasColumnName("AdminType")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(i =>i.RegDate)
            .HasColumnName("FechaRegistro")
            .HasColumnType("datetime")
            .HasMaxLength(50)
            .IsRequired();

            //configuracion de la tabla intermedia Many to Many
            builder
            .HasMany(p => p.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UsersRoles>(
                //uso de la entidad intermedia
                j => j
                .HasOne(x => x.Rol)//relacion uno a uno
                .WithMany(t => t.UsersRoles)//muchos
                .HasForeignKey(x => x.RolId), // establece rolid como llave foranea

                j => j
                .HasOne(et => et.User)
                .WithMany(et => et.UsersRoles)
                .HasForeignKey(el => el.UserId),

                j =>//union entre las tablas para userrol
                {
                    j.ToTable("userRol");
                    j.HasKey(t => new { t.UserId, t.RolId });//definir clave primaria

                });
        }
    }
}
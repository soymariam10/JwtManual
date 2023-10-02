using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;


namespace Persistencia.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");

            builder.Property(x => x.Id)
            .IsRequired();

            builder.Property(x => x.Nombre)
            .HasColumnName("RolName")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}
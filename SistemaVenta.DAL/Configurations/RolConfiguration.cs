using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> entity)
    {
        entity.HasKey(e => e.IdRol).HasName("PK__Rol");

        entity.ToTable("Rol");

        entity.Property(e => e.IdRol).HasColumnName("idRol");
        entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("fechaRegistro");
        entity.Property(e => e.Nombre)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("nombre");
    }
}
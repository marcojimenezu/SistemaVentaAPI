using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario");

        entity.ToTable("Usuario");

        entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
        entity.Property(e => e.Clave)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("clave");
        entity.Property(e => e.Correo)
            .HasMaxLength(40)
            .IsUnicode(false)
            .HasColumnName("correo");
        entity.Property(e => e.EsActivo)
            .HasDefaultValueSql("((1))")
            .HasColumnName("esActivo");
        entity.Property(e => e.FechaRegistro)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime")
            .HasColumnName("fechaRegistro");
        entity.Property(e => e.IdRol).HasColumnName("idRol");
        entity.Property(e => e.NombreCompleto)
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasColumnName("nombreCompleto");

        entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
            .HasForeignKey(d => d.IdRol)
            .HasConstraintName("FK__Usuario__idRol");
    }
}
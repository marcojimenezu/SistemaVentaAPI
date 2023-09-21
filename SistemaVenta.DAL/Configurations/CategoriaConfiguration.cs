using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> entity)
    {
        entity.HasKey(e => e.IdCategoria).HasName("PK__Categoria");

        entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
        entity.Property(e => e.EsActivo)
            .HasDefaultValueSql("((1))")
            .HasColumnName("esActivo");
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